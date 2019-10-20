using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Lien d'action d'édition contenant uniquement une icône.
    /// </summary>
    public class LinkActionEditTagHelper : LinkActionTagHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output, eLinkActionTagHelper.EDIT);
        }
    }
}