using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Fenêtre de gestion du personnel : liste, ajout, modification, suppression
    /// d'un personnel et accès à la gestion de ses absences.
    /// </summary>
    public partial class FrmGestionPersonnel : Form
    {
        /// <summary>
        /// Contrôleur de l'application.
        /// </summary>
        private Controle controle;

        /// <summary>
        /// Source de données pour le DataGridView des personnels.
        /// </summary>
        private BindingSource bdgPersonnels = new BindingSource();

        /// <summary>
        /// Indique si la saisie en cours est une modification (true) ou un ajout (false).
        /// </summary>
        private bool enModification = false;

        /// <summary>
        /// Constructeur.
        /// </summary>
        public FrmGestionPersonnel()
        {
            InitializeComponent();
            controle = new Controle();
        }

        /// <summary>
        /// Au chargement de la fenêtre : on remplit la liste déroulante des services,
        /// on affiche la liste des personnels et on masque la zone de saisie.
        /// </summary>
        private void FrmGestionPersonnel_Load(object sender, EventArgs e)
        {
            RemplirListeServices();
            RemplirListePersonnels();
            grpPersonnel.Enabled = false;
        }

        /// <summary>
        /// Remplit la liste déroulante des services.
        /// </summary>
        private void RemplirListeServices()
        {
            List<Service> lesServices = controle.GetLesServices();
            cboService.DataSource = lesServices;
        }

        /// <summary>
        /// Remplit le DataGridView avec la liste des personnels.
        /// </summary>
        private void RemplirListePersonnels()
        {
            List<Personnel> lesPersonnels = controle.GetLesPersonnels();
            bdgPersonnels.DataSource = lesPersonnels;
            dgvPersonnel.DataSource = bdgPersonnels;
            // On masque les colonnes des identifiants (inutiles à l'affichage).
            dgvPersonnel.Columns["IdPersonnel"].Visible = false;
            dgvPersonnel.Columns["IdService"].Visible = false;
            dgvPersonnel.Columns["Service"].HeaderText = "Service";
            dgvPersonnel.Columns["Tel"].HeaderText = "Téléphone";
        }

        /// <summary>
        /// Retourne le personnel sélectionné dans le DataGridView.
        /// </summary>
        /// <returns>Le personnel sélectionné, ou null si aucun.</returns>
        private Personnel GetPersonnelSelectionne()
        {
            Personnel personnel = null;
            if (bdgPersonnels.Count > 0)
            {
                personnel = (Personnel)bdgPersonnels.Current;
            }
            return personnel;
        }

        /// <summary>
        /// Active ou désactive la zone de saisie et les boutons principaux
        /// pour faciliter les manipulations pendant une saisie.
        /// </summary>
        /// <param name="enSaisie">True pendant une saisie, false sinon.</param>
        private void EnSaisie(bool enSaisie)
        {
            grpPersonnel.Enabled = enSaisie;
            dgvPersonnel.Enabled = !enSaisie;
            btnAjouter.Enabled = !enSaisie;
            btnModifier.Enabled = !enSaisie;
            btnSupprimer.Enabled = !enSaisie;
            btnGererAbsences.Enabled = !enSaisie;
        }

        /// <summary>
        /// Vide les champs de la zone de saisie.
        /// </summary>
        private void ViderLesChamps()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtTel.Text = "";
            txtMail.Text = "";
            if (cboService.Items.Count > 0)
            {
                cboService.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Clic sur "Ajouter" : prépare la zone de saisie pour un nouveau personnel.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            enModification = false;
            ViderLesChamps();
            grpPersonnel.Text = "Ajout d'un personnel";
            EnSaisie(true);
            txtNom.Focus();
        }

        /// <summary>
        /// Clic sur "Modifier" : recopie le personnel sélectionné dans la zone de saisie.
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            Personnel personnel = GetPersonnelSelectionne();
            if (personnel == null)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Information");
            }
            else
            {
                enModification = true;
                txtNom.Text = personnel.Nom;
                txtPrenom.Text = personnel.Prenom;
                txtTel.Text = personnel.Tel;
                txtMail.Text = personnel.Mail;
                cboService.SelectedItem = TrouverService(personnel.IdService);
                grpPersonnel.Text = "Modification d'un personnel";
                EnSaisie(true);
            }
        }

        /// <summary>
        /// Cherche dans la liste déroulante le service qui a l'identifiant donné.
        /// </summary>
        /// <param name="idservice">Identifiant du service recherché.</param>
        /// <returns>Le service trouvé, ou null.</returns>
        private Service TrouverService(int idservice)
        {
            Service resultat = null;
            for (int i = 0; i < cboService.Items.Count; i++)
            {
                Service service = (Service)cboService.Items[i];
                if (service.IdService == idservice)
                {
                    resultat = service;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Clic sur "Enregistrer" : contrôle la saisie puis ajoute ou modifie le personnel.
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtPrenom.Text == "")
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires.", "Information");
            }
            else
            {
                Service service = (Service)cboService.SelectedItem;
                if (enModification == true)
                {
                    Personnel personnel = GetPersonnelSelectionne();
                    Personnel personnelModifie = new Personnel(personnel.IdPersonnel, txtNom.Text,
                        txtPrenom.Text, txtTel.Text, txtMail.Text, service.IdService, service.Nom);
                    controle.UpdatePersonnel(personnelModifie);
                }
                else
                {
                    Personnel personnelAjoute = new Personnel(0, txtNom.Text, txtPrenom.Text,
                        txtTel.Text, txtMail.Text, service.IdService, service.Nom);
                    controle.AddPersonnel(personnelAjoute);
                }
                EnSaisie(false);
                RemplirListePersonnels();
            }
        }

        /// <summary>
        /// Clic sur "Annuler" : abandonne la saisie en cours.
        /// </summary>
        private void btnAnnulerSaisie_Click(object sender, EventArgs e)
        {
            EnSaisie(false);
        }

        /// <summary>
        /// Clic sur "Supprimer" : supprime le personnel sélectionné après confirmation.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Personnel personnel = GetPersonnelSelectionne();
            if (personnel == null)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Information");
            }
            else
            {
                string message = "Voulez-vous vraiment supprimer " + personnel.Nom + " " + personnel.Prenom + " ?";
                DialogResult reponse = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
                if (reponse == DialogResult.Yes)
                {
                    controle.DelPersonnel(personnel);
                    RemplirListePersonnels();
                }
            }
        }

        /// <summary>
        /// Clic sur "Gérer les absences" : ouvre la fenêtre des absences du personnel sélectionné.
        /// </summary>
        private void btnGererAbsences_Click(object sender, EventArgs e)
        {
            Personnel personnel = GetPersonnelSelectionne();
            if (personnel == null)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Information");
            }
            else
            {
                FrmGestionAbsence frmGestionAbsence = new FrmGestionAbsence(personnel);
                frmGestionAbsence.ShowDialog();
            }
        }
    }
}
