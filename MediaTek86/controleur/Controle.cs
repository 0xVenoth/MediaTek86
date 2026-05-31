using System;
using System.Collections.Generic;
using MediaTek86.dal;
using MediaTek86.modele;

namespace MediaTek86.controleur
{
    /// <summary>
    /// Contrôleur de l'application : fait le lien entre les vues et la couche
    /// d'accès aux données (AccesDonnees).
    /// </summary>
    public class Controle
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public Controle()
        {
        }

        /// <summary>
        /// Vérifie le login et le mot de passe du responsable.
        /// </summary>
        /// <param name="login">Login saisi.</param>
        /// <param name="pwd">Mot de passe saisi.</param>
        /// <returns>True si la connexion est autorisée, false sinon.</returns>
        public bool ControleAuthentification(string login, string pwd)
        {
            return AccesDonnees.ControleAuthentification(login, pwd);
        }

        /// <summary>
        /// Retourne la liste de tous les services.
        /// </summary>
        /// <returns>Liste des services.</returns>
        public List<Service> GetLesServices()
        {
            return AccesDonnees.GetLesServices();
        }

        /// <summary>
        /// Retourne la liste de tous les motifs.
        /// </summary>
        /// <returns>Liste des motifs.</returns>
        public List<Motif> GetLesMotifs()
        {
            return AccesDonnees.GetLesMotifs();
        }

        /// <summary>
        /// Retourne la liste de tous les personnels.
        /// </summary>
        /// <returns>Liste des personnels.</returns>
        public List<Personnel> GetLesPersonnels()
        {
            return AccesDonnees.GetLesPersonnels();
        }

        /// <summary>
        /// Retourne la liste des absences d'un personnel.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel.</param>
        /// <returns>Liste des absences.</returns>
        public List<Absence> GetLesAbsences(int idpersonnel)
        {
            return AccesDonnees.GetLesAbsences(idpersonnel);
        }

        /// <summary>
        /// Demande l'ajout d'un personnel.
        /// </summary>
        /// <param name="personnel">Personnel à ajouter.</param>
        public void AddPersonnel(Personnel personnel)
        {
            AccesDonnees.AddPersonnel(personnel);
        }

        /// <summary>
        /// Demande la modification d'un personnel.
        /// </summary>
        /// <param name="personnel">Personnel à modifier.</param>
        public void UpdatePersonnel(Personnel personnel)
        {
            AccesDonnees.UpdatePersonnel(personnel);
        }

        /// <summary>
        /// Demande la suppression d'un personnel.
        /// </summary>
        /// <param name="personnel">Personnel à supprimer.</param>
        public void DelPersonnel(Personnel personnel)
        {
            AccesDonnees.DelPersonnel(personnel);
        }

        /// <summary>
        /// Vérifie si une absence chevauche une autre absence du même personnel.
        /// </summary>
        /// <param name="absence">Absence à contrôler.</param>
        /// <param name="enModification">True si on modifie une absence existante.</param>
        /// <param name="ancienneDateDebut">Ancienne date de début (si modification).</param>
        /// <returns>True s'il y a chevauchement, false sinon.</returns>
        public bool AbsenceEnChevauchement(Absence absence, bool enModification, DateTime ancienneDateDebut)
        {
            return AccesDonnees.AbsenceEnChevauchement(absence, enModification, ancienneDateDebut);
        }

        /// <summary>
        /// Demande l'ajout d'une absence.
        /// </summary>
        /// <param name="absence">Absence à ajouter.</param>
        public void AddAbsence(Absence absence)
        {
            AccesDonnees.AddAbsence(absence);
        }

        /// <summary>
        /// Demande la modification d'une absence.
        /// </summary>
        /// <param name="absence">Nouvelles valeurs de l'absence.</param>
        /// <param name="ancienneDateDebut">Date de début avant modification.</param>
        public void UpdateAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            AccesDonnees.UpdateAbsence(absence, ancienneDateDebut);
        }

        /// <summary>
        /// Demande la suppression d'une absence.
        /// </summary>
        /// <param name="absence">Absence à supprimer.</param>
        public void DelAbsence(Absence absence)
        {
            AccesDonnees.DelAbsence(absence);
        }
    }
}
