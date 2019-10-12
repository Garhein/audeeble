namespace Audeeble_Shared.Options
{
    /// <summary>
    /// Options de l'API.
    /// </summary>
    public class OptionsAPI
    {
        public string BaseUrl { get; set; }
        public string UrlViewListeTiers { get; set; }

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public OptionsAPI()
        {
            this.BaseUrl            = string.Empty;
            this.UrlViewListeTiers  = string.Empty;
        }
    }
}