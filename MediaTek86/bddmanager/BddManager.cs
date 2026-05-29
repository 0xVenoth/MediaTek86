using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Classe technique d'accès à la base de données MySQL.
    /// Implémentée en singleton pour n'ouvrir qu'une seule connexion.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe.
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion à la base de données.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Commande SQL à exécuter.
        /// </summary>
        private MySqlCommand command;

        /// <summary>
        /// Curseur de lecture des résultats d'une requête de sélection.
        /// </summary>
        private MySqlDataReader reader;

        /// <summary>
        /// Constructeur privé : ouvre la connexion à la base de données.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion.</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Crée et retourne l'unique instance de la classe (singleton).
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion.</param>
        /// <returns>L'instance de BddManager.</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête de mise à jour (insert, update, delete).
        /// </summary>
        /// <param name="stringQuery">Requête SQL.</param>
        /// <param name="parameters">Paramètres de la requête (peut être null).</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête de sélection et prépare la lecture des résultats.
        /// </summary>
        /// <param name="stringQuery">Requête SQL.</param>
        /// <param name="parameters">Paramètres de la requête (peut être null).</param>
        public void ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            reader = command.ExecuteReader();
        }

        /// <summary>
        /// Avance le curseur de lecture sur la ligne suivante.
        /// </summary>
        /// <returns>True s'il reste une ligne à lire, false sinon.</returns>
        public bool Read()
        {
            return reader != null && reader.Read();
        }

        /// <summary>
        /// Retourne la valeur d'un champ de la ligne courante.
        /// </summary>
        /// <param name="nameField">Nom du champ.</param>
        /// <returns>Valeur du champ.</returns>
        public object Field(string nameField)
        {
            return reader[nameField];
        }

        /// <summary>
        /// Ferme le curseur de lecture des résultats.
        /// </summary>
        public void Close()
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
    }
}
