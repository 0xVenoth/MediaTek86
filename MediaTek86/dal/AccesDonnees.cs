using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données : gère la chaîne de connexion à la base
    /// et fournira les méthodes répondant aux demandes du contrôleur.
    /// </summary>
    public class AccesDonnees
    {
        /// <summary>
        /// Chaîne de connexion à la base de données MySQL.
        /// </summary>
        private static readonly string connectionString = "server=localhost;userid=mediatek;password=motdepasse;database=mediatek86;sslmode=none";

        /// <summary>
        /// Retourne l'instance unique du gestionnaire de base de données,
        /// initialisée avec la chaîne de connexion.
        /// </summary>
        /// <returns>L'instance de BddManager.</returns>
        public static BddManager GetBddManager()
        {
            return BddManager.GetInstance(connectionString);
        }
    }
}
