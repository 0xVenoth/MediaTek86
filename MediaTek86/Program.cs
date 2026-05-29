using System;
using System.Windows.Forms;
using MediaTek86.vue;

namespace MediaTek86
{
    // Point d'entrée de l'application
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmConnexion());
        }
    }
}
