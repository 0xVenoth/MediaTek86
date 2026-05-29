using System;
using System.Windows.Forms;
using MediaTek86.vue;

namespace MediaTek86
{
    /// <summary>
    /// Classe contenant le point d'entrée de l'application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application : ouvre la fenêtre de connexion.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmConnexion());
        }
    }
}
