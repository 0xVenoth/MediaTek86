using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Fenêtre de gestion des absences d'un personnel : liste, ajout,
    /// modification et suppression des absences.
    /// </summary>
    public partial class FrmGestionAbsence : Form
    {
        /// <summary>
        /// Contrôleur de l'application.
        /// </summary>
        private Controle controle;

        /// <summary>
        /// Personnel dont on gère les absences.
        /// </summary>
        private Personnel lePersonnel;

        /// <summary>
        /// Source de données pour le DataGridView des absences.
        /// </summary>
        private BindingSource bdgAbsences = new BindingSource();

        /// <summary>
        /// Indique si la saisie en cours est une modification (true) ou un ajout (false).
        /// </summary>
        private bool enModification = false;

        /// <summary>
        /// Date de début de l'absence avant modification (clé primaire).
        /// </summary>
        private DateTime ancienneDateDebut;

        /// <summary>
        /// Constructeur : reçoit le personnel sélectionné dans la fenêtre précédente.
        /// </summary>
        /// <param name="personnel">Personnel dont on gère les absences.</param>
        public FrmGestionAbsence(Personnel personnel)
        {
            InitializeComponent();
            controle = new Controle();
            lePersonnel = personnel;
        }

        /// <summary>
        /// Au chargement : titre avec le nom du personnel, liste déroulante des motifs,
        /// liste des absences et zone de saisie masquée.
        /// </summary>
        private void FrmGestionAbsence_Load(object sender, EventArgs e)
        {
            lblTitre.Text = "Gestion des absences de " + lePersonnel.Prenom + " " + lePersonnel.Nom;
            RemplirListeMotifs();
            RemplirListeAbsences();
            grpAbsence.Enabled = false;
        }

        /// <summary>
        /// Remplit la liste déroulante des motifs.
        /// </summary>
        private void RemplirListeMotifs()
        {
            List<Motif> lesMotifs = controle.GetLesMotifs();
            cboMotif.DataSource = lesMotifs;
        }

        /// <summary>
        /// Remplit le DataGridView avec les absences du personnel.
        /// </summary>
        private void RemplirListeAbsences()
        {
            List<Absence> lesAbsences = controle.GetLesAbsences(lePersonnel.IdPersonnel);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsences.DataSource = bdgAbsences;
            dgvAbsences.Columns["IdPersonnel"].Visible = false;
            dgvAbsences.Columns["IdMotif"].Visible = false;
            dgvAbsences.Columns["DateDebut"].HeaderText = "Date de début";
            dgvAbsences.Columns["DateFin"].HeaderText = "Date de fin";
            dgvAbsences.Columns["Motif"].HeaderText = "Motif";
        }

        /// <summary>
        /// Retourne l'absence sélectionnée dans le DataGridView.
        /// </summary>
        /// <returns>L'absence sélectionnée, ou null si aucune.</returns>
        private Absence GetAbsenceSelectionnee()
        {
            Absence absence = null;
            if (bdgAbsences.Count > 0)
            {
                absence = (Absence)bdgAbsences.Current;
            }
            return absence;
        }

        /// <summary>
        /// Active ou désactive la zone de saisie et les boutons principaux.
        /// </summary>
        /// <param name="enSaisie">True pendant une saisie, false sinon.</param>
        private void EnSaisie(bool enSaisie)
        {
            grpAbsence.Enabled = enSaisie;
            dgvAbsences.Enabled = !enSaisie;
            btnAjouter.Enabled = !enSaisie;
            btnModifier.Enabled = !enSaisie;
            btnSupprimer.Enabled = !enSaisie;
            btnFermer.Enabled = !enSaisie;
        }

        /// <summary>
        /// Cherche dans la liste déroulante le motif qui a l'identifiant donné.
        /// </summary>
        /// <param name="idmotif">Identifiant du motif recherché.</param>
        /// <returns>Le motif trouvé, ou null.</returns>
        private Motif TrouverMotif(int idmotif)
        {
            Motif resultat = null;
            for (int i = 0; i < cboMotif.Items.Count; i++)
            {
                Motif motif = (Motif)cboMotif.Items[i];
                if (motif.IdMotif == idmotif)
                {
                    resultat = motif;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Clic sur "Ajouter" : prépare la zone de saisie pour une nouvelle absence.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            enModification = false;
            dtpDateDebut.Value = DateTime.Now;
            dtpDateFin.Value = DateTime.Now;
            if (cboMotif.Items.Count > 0)
            {
                cboMotif.SelectedIndex = 0;
            }
            grpAbsence.Text = "Ajout d'une absence";
            EnSaisie(true);
        }

        /// <summary>
        /// Clic sur "Modifier" : recopie l'absence sélectionnée dans la zone de saisie.
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            Absence absence = GetAbsenceSelectionnee();
            if (absence == null)
            {
                MessageBox.Show("Veuillez sélectionner une absence.", "Information");
            }
            else
            {
                enModification = true;
                ancienneDateDebut = absence.DateDebut;
                dtpDateDebut.Value = absence.DateDebut;
                dtpDateFin.Value = absence.DateFin;
                cboMotif.SelectedItem = TrouverMotif(absence.IdMotif);
                grpAbsence.Text = "Modification d'une absence";
                EnSaisie(true);
            }
        }

        /// <summary>
        /// Clic sur "Enregistrer" : contrôle la saisie puis ajoute ou modifie l'absence.
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (dtpDateFin.Value < dtpDateDebut.Value)
            {
                MessageBox.Show("La date de fin doit être après la date de début.", "Information");
            }
            else
            {
                Motif motif = (Motif)cboMotif.SelectedItem;
                Absence absence = new Absence(lePersonnel.IdPersonnel, dtpDateDebut.Value,
                    dtpDateFin.Value, motif.IdMotif, motif.Libelle);
                if (enModification == true)
                {
                    controle.UpdateAbsence(absence, ancienneDateDebut);
                }
                else
                {
                    controle.AddAbsence(absence);
                }
                EnSaisie(false);
                RemplirListeAbsences();
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
        /// Clic sur "Supprimer" : supprime l'absence sélectionnée après confirmation.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Absence absence = GetAbsenceSelectionnee();
            if (absence == null)
            {
                MessageBox.Show("Veuillez sélectionner une absence.", "Information");
            }
            else
            {
                string message = "Voulez-vous vraiment supprimer cette absence ?";
                DialogResult reponse = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
                if (reponse == DialogResult.Yes)
                {
                    controle.DelAbsence(absence);
                    RemplirListeAbsences();
                }
            }
        }

        /// <summary>
        /// Clic sur "Fermer" : ferme la fenêtre des absences.
        /// </summary>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
