using System.ComponentModel.DataAnnotations.Schema;

namespace Audeeble_Shared.Entity.Tiers
{
    /// <summary>
    /// Données récupérées par la vue SQL 'V_LISTE_TIERS'.
    /// </summary>
    [Table("V_LISTE_TIERS", Schema = "dbo")]
    public class ViewListeTiers
    {
        #region Informations communes

        [Column("PERS_ID")]
        public int ID { get; set; }

        [Column("IS_PERS_PPHY")]
        public bool EstPersonnePhysique { get; set; }

        [Column("PERS_ARCHIVE_ON")]
        public bool EstArchive { get; set; }

        #endregion

        #region Personne physique

        [Column("PPHY_NOM_USAGE")]
        public string NomUsage { get; set; }

        [Column("PPHY_NOM_NAISSANCE")]
        public string NomNaissance { get; set; }

        [Column("PPHY_PRENOM")]
        public string Prenom { get; set; }

        [Column("PCIV_ABREVIATION")]
        public string CiviliteAbreviation { get; set; }

        [Column("PCIV_LIBELLE")]
        public string CiviliteLibelle { get; set; }

        #endregion

        #region Personne morale

        [Column("PMOR_RAISON_SOCIALE")]
        public string RaisonSociale { get; set; }

        #endregion

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public ViewListeTiers() { }
    }
}