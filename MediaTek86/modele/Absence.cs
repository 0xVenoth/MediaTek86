using System;

namespace MediaTek86.modele
{
    // Absence d'un membre du personnel
    public class Absence
    {
        public int IdPersonnel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int IdMotif { get; set; }
        public string Motif { get; set; }

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
