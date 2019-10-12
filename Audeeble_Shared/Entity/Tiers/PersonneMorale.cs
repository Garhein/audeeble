using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audeeble_Shared.Entity.Tiers
{
    /// <summary>
    /// Personne morale.
    /// </summary>
    [Table("T_E_PERS_MORALE_PMOR", Schema = "dbo")]
    public class PersonneMorale : Personne
    {
        [Required(ErrorMessage = "La raison sociale est obligatoire")]
        [Display(Name = "Raison sociale")]
        [Column("PMOR_RAISON_SOCIALE")]
        [StringLength(80)]        
        public string RaisonSociale { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public PersonneMorale() { }
    }
}