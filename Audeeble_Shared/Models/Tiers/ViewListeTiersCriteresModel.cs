using Audeeble_Shared.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Audeeble_Shared.Models.Tiers
{
    /// <summary>
    /// Critères de recherche applicables à la liste des tiers.
    /// </summary>
    public class ViewListeTiersCriteresModel : QueryStringModel
    {
        [QueryStringParameter("inclureArchive")]
        [Display(Name = "Afficher les tiers archivés")]
        [Description("Si coché, les tiers archivés sont affichés")]        
        public bool InclureArchive { get; set; }

        #region Personnes physiques

        [QueryStringParameter("inclurePersPhysique")]
        [Display(Name = "Personnes physiques")]
        [Description("Si coché, les personnes physiques sont incluses dans la recherche")]
        public bool InclurePersPhysique { get; set; }
        
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        #endregion

        #region Personnes morales

        [QueryStringParameter("inclurePersMorale")]
        [Display(Name = "Personnes morales")]
        [Description("Si coché, les personnes morales sont incluses dans la recherche")]
        public bool InclurePersMorale { get; set; }
        
        [Display(Name = "Raison sociale")]
        public string RaisonSociale { get; set; }

        #endregion

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public ViewListeTiersCriteresModel()
        {
            this.InclureArchive         = false;
            this.InclurePersPhysique    = true;
            this.Nom                    = string.Empty;
            this.Prenom                 = string.Empty;
            this.InclurePersMorale      = true;
            this.RaisonSociale          = string.Empty;
        }
    }
}