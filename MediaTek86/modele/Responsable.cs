namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier correspondant à la table 'responsable'
    /// (login et mot de passe de connexion à l'application).
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Login du responsable.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe du responsable.
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="login">Login du responsable.</param>
        /// <param name="pwd">Mot de passe du responsable.</param>
        public Responsable(string login, string pwd)
        {
            Login = login;
            Pwd = pwd;
        }
    }
}
