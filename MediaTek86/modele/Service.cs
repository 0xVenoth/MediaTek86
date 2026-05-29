namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier correspondant à la table 'service'.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant du service.
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Nom du service.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="idService">Identifiant du service.</param>
        /// <param name="nom">Nom du service.</param>
        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }

        /// <summary>
        /// Représentation du service sous forme de chaîne (pour l'affichage en liste).
        /// </summary>
        /// <returns>Le nom du service.</returns>
        public override string ToString()
        {
            return Nom;
        }
    }
}
