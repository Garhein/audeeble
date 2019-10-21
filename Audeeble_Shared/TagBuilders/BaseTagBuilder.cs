using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace Audeeble_Shared.TagBuilders
{
    /// <summary>
    /// Classe de base des <see cref="TagBuilder"/> personnalisés.
    /// </summary>
    public abstract class BaseTagBuilder : TagBuilder
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="tagName"></param>
        public BaseTagBuilder(string tagName) : base(tagName) { }

        /// <summary>
        /// Conversion du <see cref="TagBuilder"/> en un <see cref="string"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            
            using (StringWriter writer = new StringWriter())
            {
                this.WriteTo(writer, HtmlEncoder.Default);
                retVal = writer.ToString();
            }

            return retVal;
        }
    }
}