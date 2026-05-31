using System;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    /// <summary>
    /// Fenêtre de connexion du responsable (cas d'utilisation "Se connecter").
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// Contrôleur de l'application.
        /// </summary>
        private Controle controle;

        /// <summary>
        /// Constructeur : initialise les composants et le contrôleur.
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            controle = new Controle();
        }

        /// <summary>
        /// Clic sur le bouton "Se connecter" : vérifie le login et le mot de passe.
        /// Si c'est correct, on ouvre la fenêtre de gestion du personnel,
        /// sinon on affiche un message d'erreur.
        /// </summary>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string pwd = txtPwd.Text;
            if (login == "" || pwd == "")
            {
                MessageBox.Show("Veuillez saisir le login et le mot de passe.", "Information");
            }
            else
            {
                if (controle.ControleAuthentification(login, pwd) == true)
                {
                    FrmGestionPersonnel frmGestionPersonnel = new FrmGestionPersonnel();
                    this.Hide();
                    frmGestionPersonnel.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.", "Erreur");
                    txtPwd.Clear();
                    txtLogin.Focus();
                }
            }
        }

        /// <summary>
        /// Clic sur le bouton "Annuler" : ferme l'application.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
