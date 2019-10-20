using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Audeeble_Shared.TagHelpers
{
    /// <summary>
    /// Tag helper créant un lien d'action d'édition contenant uniquement une icône.
    /// </summary>
    public class ButtonActionEditTagHelper : ButtonActionTagHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output, eButtonActionTagHelper.EDIT);
        }
    }
}