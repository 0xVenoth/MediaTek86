namespace MediaTek86.modele
{
    // Responsable du personnel (connexion à l'application)
    public class Responsable
    {
        public string Login { get; set; }
        public string Pwd { get; set; }

        public Responsable(string login, string pwd)
        {
            Login = login;
            Pwd = pwd;
        }
    }
}
