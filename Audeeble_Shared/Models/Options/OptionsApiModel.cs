namespace Audeeble_Shared.Models.Options
{
    /// <summary>
    /// Options de l'API.
    /// </summary>
    public class OptionsApiModel
    {
        public string BaseUrl { get; set; }
        public string UrlViewListeTiers { get; set; }
        public string UrlTiersCivilite { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public OptionsApiModel()
        {
            this.BaseUrl            = string.Empty;
            this.UrlViewListeTiers  = string.Empty;
            this.UrlTiersCivilite   = string.Empty;
        }
    }
}