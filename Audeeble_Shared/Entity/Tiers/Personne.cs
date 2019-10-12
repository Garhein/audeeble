using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audeeble_Shared.Entity.Tiers
{
    /// <summary>
    /// Personne.
    /// </summary>
    [Table("T_E_PERSONNE_PERS", Schema = "dbo")]
    public class Personne : BaseEntity
    {
        [Required]
        [Column("PERS_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int ID { get; set; }

        [Required]
        [Column("PERS_ARCHIVE_ON")]
        [Display(Name = "Archivé")]
        public bool EstArchive { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public Personne() { }
    }
}