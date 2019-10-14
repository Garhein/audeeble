using System.Collections.Generic;
using System.Linq;

namespace Audeeble_Shared.Helpers
{
    /// <summary>
    /// Helpers sur les énumérables.
    /// </summary>
    public static class EnumerableHelper
    {
        /// <summary>
        /// Vérifie si <paramref name="source"/> est NULL ou ne contient aucune valeur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Vérifie si <paramref name="source"/> n'est pas NULL et contient au moins 1 valeur.
        /// Retourne l'inverse de <see cref="IsEmpty{T}(IEnumerable{T})"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return !IsEmpty(source);
        }

        /// <summary>
        /// Vérifie si <paramref name="dic"/> existe, s'il contient des valeurs et si la clé existe.        
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExistAndContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
        {
            return IsNotEmpty(dic) && key != null && dic.ContainsKey(key);
        }

        /// <summary>
        /// Vérifie si <paramref name="liste"/> existe, si elle contient des valeurs et si la valeur existe.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="liste"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ExistAndContainsKey<TValue>(this IEnumerable<TValue> liste, TValue value)
        {
            return IsNotEmpty(liste) && value != null && liste.Contains(value);
        }
    }
}