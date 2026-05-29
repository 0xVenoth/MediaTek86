using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier correspondant à la table 'absence'.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant du personnel concerné par l'absence.
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Date de début de l'absence.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence.
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Identifiant du motif de l'absence.
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Libellé du motif de l'absence.
        /// </summary>
        public string Motif { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début.</param>
        /// <param name="dateFin">Date de fin.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        /// <param name="motif">Libellé du motif.</param>
        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin,
                       int idMotif, string motif)
        {
            IdPersonnel = idPersonnel;
            DateDebut = dateDebut;
            DateFin = dateFin;
            IdMotif = idMotif;
            Motif = motif;
        }
    }
}
