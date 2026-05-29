namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier correspondant à la table 'personnel'.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Identifiant du personnel.
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Nom du personnel.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du personnel.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone du personnel.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Adresse mail du personnel.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Identifiant du service auquel appartient le personnel.
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Nom du service auquel appartient le personnel.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        /// <param name="mail">Adresse mail.</param>
        /// <param name="idService">Identifiant du service.</param>
        /// <param name="service">Nom du service.</param>
        public Personnel(int idPersonnel, string nom, string prenom, string tel,
                         string mail, int idService, string service)
        {
            IdPersonnel = idPersonnel;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            IdService = idService;
            Service = service;
        }
    }
}
