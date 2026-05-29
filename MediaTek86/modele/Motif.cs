namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier correspondant à la table 'motif'.
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant du motif.
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Libellé du motif.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="idMotif">Identifiant du motif.</param>
        /// <param name="libelle">Libellé du motif.</param>
        public Motif(int idMotif, string libelle)
        {
            IdMotif = idMotif;
            Libelle = libelle;
        }

        /// <summary>
        /// Représentation du motif sous forme de chaîne (pour l'affichage en liste).
        /// </summary>
        /// <returns>Le libellé du motif.</returns>
        public override string ToString()
        {
            return Libelle;
        }
    }
}
