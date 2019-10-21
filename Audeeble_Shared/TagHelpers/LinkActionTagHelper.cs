using Audeeble_Shared.TagBuilders;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Lien d'action contenant uniquement une icône.
    /// </summary>
    public class LinkActionTagHelper : TagHelper
    {
        // =-=-=-
        // Propriétés disponibles sur le tag
        // =-=-=-

        public string               AreaName { get; set; }
        public string               ControllerName { get; set; }
        public string               ActionName { get; set; }
        public string               RouteId { get; set; }
        public eFontAwesomeIcon     FaIcon { get; set; }
        public eFontAwesomeStyle    FaStyle { get; set; }

        /// <summary>
        /// Process.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <param name="actionType"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            // =-=-=-
            // Création de l'icône
            // =-=-=-

            FontAwesomeTagBuilder faIcon = new FontAwesomeTagBuilder(this.FaIcon, this.FaStyle);

            // =-=-=-
            // Définition de l'attribut 'href' du lien
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

            string hrefAttribute = string.Format("{0}{1}{2}{3}",
                                                 this.AreaName,
                                                 this.ControllerName,
                                                 this.ActionName,
                                                 this.RouteId);

            // =-=-=-
            // Actions sur le TagHelper
            // =-=-=-

            // Ajout de l'attribut 'href'
            output.Attributes.SetAttribute("href", hrefAttribute);

            // Retrait du contenu
            output.Content.SetContent(string.Empty);

            // Ajout de l'icône
            output.PreContent.SetHtmlContent(faIcon.ToString());

            // Modification de la balise
            output.TagName = "a";
        }
    }
}
