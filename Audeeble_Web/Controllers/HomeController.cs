using Audeeble_Shared.Entity.Tiers;
using Audeeble_Shared.Options;
using Audeeble_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Audeeble_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OptionsAPI _optionsAPI;

        public HomeController(IOptionsMonitor<OptionsAPI> options)
        {
            this._optionsAPI = options.CurrentValue;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ViewListeTiers> listeTiers = new List<ViewListeTiers>();

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(string.Format("{0}{1}",
                                                this._optionsAPI.BaseUrl,
                                                this._optionsAPI.UrlViewListeTiers));
                
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string content  = await response.Content.ReadAsStringAsync();
                        listeTiers      = JsonConvert.DeserializeObject<IEnumerable<ViewListeTiers>>(content);
                    }
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}