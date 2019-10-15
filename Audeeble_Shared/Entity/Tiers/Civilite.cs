using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audeeble_Shared.Entity.Tiers
{
    /// <summary>
    /// Personne.
    /// </summary>
    [Table("T_R_PERS_CIVILITE_PCIV", Schema = "dbo")]
    public class Civilite : BaseEntity
    {
        [Required]
        [Column("PCIV_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int ID { get; set; }

        [Required]
        [Column("PCIV_ABREVIATION")]
        [StringLength(4)]
        [Display(Name = "Abréviation")]
        public string Abreviation { get; set; }

        [Required]
        [Column("PCIV_LIBELLE")]
        [StringLength(8)]
        [Display(Name = "Libellé")]
        public string Libelle { get; set; }

        [Required]
        [Column("PCIV_ARCHIVE_ON")]
        [Display(Name = "Archivée")]
        public bool EstArchive { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public Civilite() { }
    }

    /// <summary>
    /// Énumération permettant de connaître l'identifiant interne d'une civilité.
    /// </summary>
    public enum eCivilite : int
    {
        MONSIEUR = 1,
        MADAME   = 2
    }
}