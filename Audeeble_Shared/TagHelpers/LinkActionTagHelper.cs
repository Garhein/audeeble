using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Lien d'action contenant uniquement une icône.
    /// </summary>
    public abstract class LinkActionTagHelper : TagHelper
    {
        // =-=-=-
        // Propriétés disponibles sur le tag
        // =-=-=-

        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RouteId { get; set; }

        // =-=-=-
        // Constantes
        // =-=-=-

        public const string CSTS_TAG_CLASSE_BASE    = "btn-action";
        public const string CSTS_TAG_CLASSE_EDIT    = "btn-action-edit";
        public const string CSTS_TAG_CLASSE_DELETE  = "btn-action-delete";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="actionType"></param>
        public void Process(TagHelperContext context, TagHelperOutput output, eLinkActionTagHelper actionType)
        {
            base.Process(context, output);

            // =-=-=-
            // Définition des classes
            // =-=-=-

            List<string> listeClasses = new List<string> { LinkActionTagHelper.CSTS_TAG_CLASSE_BASE };

            switch (actionType)
            {
                case eLinkActionTagHelper.EDIT:
                    {
                        listeClasses.Add(LinkActionTagHelper.CSTS_TAG_CLASSE_EDIT);
                        break;
                    }
                case eLinkActionTagHelper.DELETE:
                    {
                        listeClasses.Add(LinkActionTagHelper.CSTS_TAG_CLASSE_DELETE);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            output.Attributes.SetAttribute("class", string.Join(" ", listeClasses));

            // =-=-=-
            // Définition du lien
            // =-=-=-

            if (!string.IsNullOrEmpty(this.AreaName))
            {
                this.AreaName = "/" + this.AreaName;
            }

            if (!string.IsNullOrEmpty(this.ControllerName))
            {
                this.ControllerName = "/" + this.ControllerName;
            }

            if (!string.IsNullOrEmpty(this.ActionName))
            {
                this.ActionName = "/" + this.ActionName;
            }

            if (!string.IsNullOrEmpty(this.RouteId))
            {
                this.RouteId = "/" + this.RouteId;
            }

            // Ajout de l'attribut 'href' et retrait du contenu
            output.Attributes.SetAttribute("href", string.Format("{0}{1}{2}{3}", 
                                                                 this.AreaName,
                                                                 this.ControllerName,
                                                                 this.ActionName,
                                                                 this.RouteId));

            output.Content.SetContent(string.Empty);

            // =-=-=-
            // Remplacement de la balise
            // =-=-=-

            output.TagName = "a";
        }
    }

    /// <summary>
    /// Énumération des actions disponibles.
    /// </summary>
    public enum eLinkActionTagHelper : int
    {
        EDIT    = 1,
        DELETE  = 2
    }
}
