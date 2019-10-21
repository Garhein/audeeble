using System.Collections.Generic;

namespace Audeeble_Shared.TagBuilders
{
    /// <summary>
    /// Création d'une icône FontAwesome.
    /// </summary>
    public class FontAwesomeTagBuilder : BaseTagBuilder
    {        
        private const eFontAwesomeIcon CSTS_DEFAULT_ICON   = eFontAwesomeIcon.EDIT;
        private const eFontAwesomeStyle CSTS_DEFAULT_STYLE = eFontAwesomeStyle.SOLID;

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public FontAwesomeTagBuilder() : base("i") { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="icon">Icône à afficher.</param>
        /// <param name="style">Style à utiliser.</param>
        public FontAwesomeTagBuilder(eFontAwesomeIcon icon, eFontAwesomeStyle style) : base("i")
        {
            // Icône
            if (FontAwesomeTagBuilder.DicoIconClassName.ContainsKey(icon))
            {
                this.AddCssClass(FontAwesomeTagBuilder.DicoIconClassName[icon]);
            }
            else
            {
                this.AddCssClass(FontAwesomeTagBuilder.DicoIconClassName[FontAwesomeTagBuilder.CSTS_DEFAULT_ICON]);
            }

            // Style
            if (FontAwesomeTagBuilder.DicoStyleClassName.ContainsKey(style))
            {
                this.AddCssClass(FontAwesomeTagBuilder.DicoStyleClassName[style]);
            }
            else
            {
                this.AddCssClass(FontAwesomeTagBuilder.DicoStyleClassName[FontAwesomeTagBuilder.CSTS_DEFAULT_STYLE]);
            }
        }

        #region Dictionnaires des correspondances

        /// <summary>
        /// Dictionnaire de correspondance entre l'énumération et la classe CSS de l'icône.
        /// </summary>
        private static Dictionary<eFontAwesomeIcon, string> DicoIconClassName = new Dictionary<eFontAwesomeIcon, string>()
            {
                { eFontAwesomeIcon.EDIT, "fa-edit" },
                { eFontAwesomeIcon.DELETE, "fa-trash-alt" }
            };

        /// <summary>
        /// Dictionnaire de correspondance entre l'énumération et la classe CSS du style.
        /// </summary>
        private static Dictionary<eFontAwesomeStyle, string> DicoStyleClassName = new Dictionary<eFontAwesomeStyle, string>()
        {
            { eFontAwesomeStyle.SOLID, "fas" },
            { eFontAwesomeStyle.REGULAR, "far" },
            { eFontAwesomeStyle.LIGHT, "fal" }
        };

        #endregion
    }

    /// <summary>
    /// Énumération des icônes disponibles.
    /// </summary>
    public enum eFontAwesomeIcon : int
    {
        EDIT    = 1,
        DELETE  = 2,
    }

    /// <summary>
    /// Énumération des différents styles disponibles.
    /// </summary>
    public enum eFontAwesomeStyle : int
    {
        SOLID   = 1,
        REGULAR = 2,
        LIGHT   = 3
    }
}