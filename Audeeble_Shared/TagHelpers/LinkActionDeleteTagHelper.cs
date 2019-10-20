using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Lien d'action de suppression contenant uniquement une icône.
    /// </summary>
    public class LinkActionDeleteTagHelper : LinkActionTagHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output, eLinkActionTagHelper.DELETE);
        }
    }
}