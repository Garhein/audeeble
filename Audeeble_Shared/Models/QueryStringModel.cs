using Audeeble_Shared.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;

namespace Audeeble_Shared.Models
{
    /// <summary>
    /// Classe de base des modèles permettant de générer un <see cref="QueryString"/>.
    /// </summary>
    public class QueryStringModel
    {
        /// <summary>
        /// Construction du composant de l'URI, en fonction de l'attribut personnalisé <see cref="QueryStringParameterAttribute"/>.
        /// </summary>
        /// <returns><see cref="string"/> représentant les paramètres de l'URI.</returns>
        public string ToUriComponent()
        { 
            QueryString qs            = new QueryString();            
            Type myType               = this.GetType();
            PropertyInfo[] properties = myType.GetProperties();

            foreach (PropertyInfo pi in properties)
            {
                QueryStringParameterAttribute attr = pi.GetCustomAttribute(typeof(QueryStringParameterAttribute)) as QueryStringParameterAttribute;
                if (attr != null)
                {
                    object objValue = pi.GetValue(this);
                    if (objValue != null)
                    {
                        qs = qs.Add(attr.UriParameterName, objValue.ToString());
                    }
                }
            }
            
            return qs.ToUriComponent();
        }
    }
}