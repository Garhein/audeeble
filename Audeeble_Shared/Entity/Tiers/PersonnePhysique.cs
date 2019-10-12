using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audeeble_Shared.Entity.Tiers
{
    /// <summary>
    /// Personne physique.
    /// </summary>
    [Table("T_E_PERS_PHYSIQUE_PPHY", Schema = "dbo")]
    public class PersonnePhysique : Personne
    {
        [Required(ErrorMessage = "Le nom d'usage est obligatoire")]
        [Display(Name = "Nom d'usage")]
        [Column("PPHY_NOM_USAGE")]
        [StringLength(32)]
        public string NomUsage { get; set; }

        [Required(ErrorMessage = "Le nom de naissance est obligatoire")]
        [Display(Name = "Nom de naissance")]
        [Column("PPHY_NOM_NAISSANCE")]
        [StringLength(32)]
        public string NomNaissance { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public PersonnePhysique() { }
    }
}