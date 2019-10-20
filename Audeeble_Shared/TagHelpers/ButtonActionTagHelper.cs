using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Tag helper de création d'un lien d'action contenant uniquement une icône.
    /// </summary>
    public abstract class ButtonActionTagHelper : TagHelper
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
        /// <param name="className"></param>
        public void Process(TagHelperContext context, TagHelperOutput output, eButtonActionTagHelper actionType)
        {
            base.Process(context, output);

            // =-=-=-
            // Définition des classes
            // =-=-=-

            List<string> listeClasses = new List<string> { ButtonActionTagHelper.CSTS_TAG_CLASSE_BASE };

            switch (actionType)
            {
                case eButtonActionTagHelper.EDIT:
                    {
                        listeClasses.Add(ButtonActionTagHelper.CSTS_TAG_CLASSE_EDIT);
                        break;
                    }
                case eButtonActionTagHelper.DELETE:
                    {
                        listeClasses.Add(ButtonActionTagHelper.CSTS_TAG_CLASSE_DELETE);
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
    public enum eButtonActionTagHelper : int
    {
        EDIT    = 1,
        DELETE  = 2
    }
}
