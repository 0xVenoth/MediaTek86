using System;
using System.Collections.Generic;
using MediaTek86.bddmanager;
using MediaTek86.modele;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données : contient la chaîne de connexion et toutes
    /// les requêtes SQL (couche d'accès aux données du MVC).
    /// </summary>
    public class AccesDonnees
    {
        /// <summary>
        /// Chaîne de connexion à la base de données MySQL.
        /// On utilise l'utilisateur applicatif créé par le script mediatek86.sql.
        /// </summary>
        private static string connectionString = "server=localhost;userid=mediatek86user;password=MediaTek86!2026;database=mediatek86;sslmode=none";

        /// <summary>
        /// Retourne l'instance unique du gestionnaire de base de données.
        /// </summary>
        /// <returns>L'instance de BddManager.</returns>
        public static BddManager GetBddManager()
        {
            return BddManager.GetInstance(connectionString);
        }

        /// <summary>
        /// Vérifie le login et le mot de passe du responsable.
        /// Le mot de passe est chiffré en SHA2 256 bits directement par MySQL.
        /// </summary>
        /// <param name="login">Login saisi.</param>
        /// <param name="pwd">Mot de passe saisi.</param>
        /// <returns>True si le couple login/mot de passe existe, false sinon.</returns>
        public static bool ControleAuthentification(string login, string pwd)
        {
            bool trouve = false;
            string req = "select login from responsable where login = @login and pwd = SHA2(@pwd, 256)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@login", login);
            parameters.Add("@pwd", pwd);
            BddManager curs = GetBddManager();
            curs.ReqSelect(req, parameters);
            if (curs.Read())
            {
                trouve = true;
            }
            curs.Close();
            return trouve;
        }

        /// <summary>
        /// Récupère la liste de tous les services.
        /// </summary>
        /// <returns>Liste des services.</returns>
        public static List<Service> GetLesServices()
        {
            List<Service> lesServices = new List<Service>();
            string req = "select idservice, nom from service order by nom";
            BddManager curs = GetBddManager();
            curs.ReqSelect(req);
            while (curs.Read())
            {
                int idservice = (int)curs.Field("idservice");
                string nom = (string)curs.Field("nom");
                Service service = new Service(idservice, nom);
                lesServices.Add(service);
            }
            curs.Close();
            return lesServices;
        }

        /// <summary>
        /// Récupère la liste de tous les motifs d'absence.
        /// </summary>
        /// <returns>Liste des motifs.</returns>
        public static List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            string req = "select idmotif, libelle from motif order by libelle";
            BddManager curs = GetBddManager();
            curs.ReqSelect(req);
            while (curs.Read())
            {
                int idmotif = (int)curs.Field("idmotif");
                string libelle = (string)curs.Field("libelle");
                Motif motif = new Motif(idmotif, libelle);
                lesMotifs.Add(motif);
            }
            curs.Close();
            return lesMotifs;
        }

        /// <summary>
        /// Récupère la liste de tous les personnels avec le nom de leur service.
        /// </summary>
        /// <returns>Liste des personnels.</returns>
        public static List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            string req = "select p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, p.idservice, s.nom as service ";
            req += "from personnel p join service s on p.idservice = s.idservice ";
            req += "order by p.nom, p.prenom";
            BddManager curs = GetBddManager();
            curs.ReqSelect(req);
            while (curs.Read())
            {
                int idpersonnel = (int)curs.Field("idpersonnel");
                string nom = (string)curs.Field("nom");
                string prenom = (string)curs.Field("prenom");
                string tel = "";
                if (curs.Field("tel") != null)
                {
                    tel = (string)curs.Field("tel");
                }
                string mail = "";
                if (curs.Field("mail") != null)
                {
                    mail = (string)curs.Field("mail");
                }
                int idservice = (int)curs.Field("idservice");
                string service = (string)curs.Field("service");
                Personnel personnel = new Personnel(idpersonnel, nom, prenom, tel, mail, idservice, service);
                lesPersonnels.Add(personnel);
            }
            curs.Close();
            return lesPersonnels;
        }

        /// <summary>
        /// Récupère la liste des absences d'un personnel, avec le libellé du motif.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel concerné.</param>
        /// <returns>Liste des absences.</returns>
        public static List<Absence> GetLesAbsences(int idpersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            string req = "select a.idpersonnel, a.datedebut, a.datefin, a.idmotif, m.libelle as motif ";
            req += "from absence a join motif m on a.idmotif = m.idmotif ";
            req += "where a.idpersonnel = @idpersonnel ";
            req += "order by a.datedebut desc";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", idpersonnel);
            BddManager curs = GetBddManager();
            curs.ReqSelect(req, parameters);
            while (curs.Read())
            {
                DateTime datedebut = (DateTime)curs.Field("datedebut");
                DateTime datefin = (DateTime)curs.Field("datefin");
                int idmotif = (int)curs.Field("idmotif");
                string motif = (string)curs.Field("motif");
                Absence absence = new Absence(idpersonnel, datedebut, datefin, idmotif, motif);
                lesAbsences.Add(absence);
            }
            curs.Close();
            return lesAbsences;
        }

        /// <summary>
        /// Ajoute un personnel dans la base de données.
        /// </summary>
        /// <param name="personnel">Personnel à ajouter.</param>
        public static void AddPersonnel(Personnel personnel)
        {
            string req = "insert into personnel (nom, prenom, tel, mail, idservice) ";
            req += "values (@nom, @prenom, @tel, @mail, @idservice)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nom", personnel.Nom);
            parameters.Add("@prenom", personnel.Prenom);
            parameters.Add("@tel", personnel.Tel);
            parameters.Add("@mail", personnel.Mail);
            parameters.Add("@idservice", personnel.IdService);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Modifie un personnel dans la base de données.
        /// </summary>
        /// <param name="personnel">Personnel à modifier.</param>
        public static void UpdatePersonnel(Personnel personnel)
        {
            string req = "update personnel set nom = @nom, prenom = @prenom, tel = @tel, ";
            req += "mail = @mail, idservice = @idservice where idpersonnel = @idpersonnel";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", personnel.IdPersonnel);
            parameters.Add("@nom", personnel.Nom);
            parameters.Add("@prenom", personnel.Prenom);
            parameters.Add("@tel", personnel.Tel);
            parameters.Add("@mail", personnel.Mail);
            parameters.Add("@idservice", personnel.IdService);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Supprime un personnel de la base de données.
        /// </summary>
        /// <param name="personnel">Personnel à supprimer.</param>
        public static void DelPersonnel(Personnel personnel)
        {
            string req = "delete from personnel where idpersonnel = @idpersonnel";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", personnel.IdPersonnel);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Ajoute une absence dans la base de données.
        /// </summary>
        /// <param name="absence">Absence à ajouter.</param>
        public static void AddAbsence(Absence absence)
        {
            string req = "insert into absence (idpersonnel, datedebut, datefin, idmotif) ";
            req += "values (@idpersonnel, @datedebut, @datefin, @idmotif)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", absence.IdPersonnel);
            parameters.Add("@datedebut", absence.DateDebut);
            parameters.Add("@datefin", absence.DateFin);
            parameters.Add("@idmotif", absence.IdMotif);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Modifie une absence. La date de début fait partie de la clé primaire,
        /// on a donc besoin de l'ancienne date de début pour retrouver la ligne.
        /// </summary>
        /// <param name="absence">Nouvelles valeurs de l'absence.</param>
        /// <param name="ancienneDateDebut">Date de début avant modification.</param>
        public static void UpdateAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            string req = "update absence set datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif ";
            req += "where idpersonnel = @idpersonnel and datedebut = @anciennedatedebut";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", absence.IdPersonnel);
            parameters.Add("@datedebut", absence.DateDebut);
            parameters.Add("@datefin", absence.DateFin);
            parameters.Add("@idmotif", absence.IdMotif);
            parameters.Add("@anciennedatedebut", ancienneDateDebut);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="absence">Absence à supprimer.</param>
        public static void DelAbsence(Absence absence)
        {
            string req = "delete from absence where idpersonnel = @idpersonnel and datedebut = @datedebut";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", absence.IdPersonnel);
            parameters.Add("@datedebut", absence.DateDebut);
            BddManager curs = GetBddManager();
            curs.ReqUpdate(req, parameters);
        }
    }
}
