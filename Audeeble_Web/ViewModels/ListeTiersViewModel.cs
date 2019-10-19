using Audeeble_Shared.Entity.Tiers;
using Audeeble_Shared.Models.Tiers;
using System.Collections.Generic;

namespace Audeeble_Web.ViewModels
{
    /// <summary>
    /// Modèle d'affichage des critères de recherche et de la liste des tiers.
    /// </summary>
    public class ListeTiersViewModel
    {
        public ViewListeTiersCriteresModel Criteres { get; set; }
        public IEnumerable<ViewListeTiers> ListeTiers { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public ListeTiersViewModel() { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="criteres">Critères de recherche.</param>
        /// <param name="listeTiers">Liste des tiers à afficher.</param>
        public ListeTiersViewModel(ViewListeTiersCriteresModel criteres,
                                   IEnumerable<ViewListeTiers> listeTiers)
        {
            this.Criteres   = criteres;
            this.ListeTiers = listeTiers;
        }
    }
}