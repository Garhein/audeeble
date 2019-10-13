using System;

namespace Audeeble_Shared.Attributes
{
    /// <summary>
    /// Attribut personnalisé permettant la génération automatique d'un <see cref="Microsoft.AspNetCore.Http.QueryString"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryStringAttribute : Attribute
    {
        public string UriParameterName { get; set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="uriParameterName">Nom du paramètre dans l'URI.</param>
        public QueryStringAttribute(string uriParameterName)
        {
            this.UriParameterName = uriParameterName;
        }
    }
}