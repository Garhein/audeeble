﻿using Audeeble_Shared.Entity.Tiers;
using Audeeble_Shared.Models.Options;
using Audeeble_Shared.Models.Tiers;
using Audeeble_Shared.Utils;
using Audeeble_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Audeeble_Web.Controllers
{
    public class TiersController : Controller
    {
        private readonly OptionsApiModel _optionsAPI;

        public TiersController(IOptionsMonitor<OptionsApiModel> options)
        {
            this._optionsAPI = options.CurrentValue;
        }

        /// <summary>
        /// Affichage initial de la liste des tiers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewListeTiersCriteresModel criteres    = new ViewListeTiersCriteresModel();
            IEnumerable<ViewListeTiers> listeTiers  = await this.GetListeTiersAsync(criteres);
            return View(new ListeTiersViewModel(criteres, listeTiers));
        }


        [HttpPost]
        public async Task<PartialViewResult> Rechercher(ViewListeTiersCriteresModel criteres)
        {            
            
            IEnumerable<ViewListeTiers> listeTiers = await this.GetListeTiersAsync(criteres);            

            return PartialView("_ListeTiers", listeTiers);
        }

        [HttpGet]
        public JsonResult AjaxRequest()
        {
            AjaxResponse ajax  = new AjaxResponse();

            try
            {
                bool ajaxBool       = true;
                string ajaxString   = "Ajax request receive Json !";
                DateTime ajaxDate   = DateTime.Now.Date.AddDays(3);
                string ajaxStrDate  = "/Date(1572083581000)/";
                ajax.ValeursRetour  = new { ajaxBool, ajaxString, ajaxDate, ajaxStrDate };

                ajax.AddError("Erreur manuelle !", false);

                int i = 10;
                int j = 0;
                int k = i / j;
            }
            catch (Exception ex)
            {
                ajax.AddException(ex);
            }

            return Json(ajax);
        }

        /// <summary>
        /// Exécution de la recherche des tiers.
        /// </summary>
        /// <param name="criteres">Critères de la recherche.</param>
        /// <returns>Liste des tiers correspondant aux critères de la recherche.</returns>
        private async Task<IEnumerable<ViewListeTiers>> GetListeTiersAsync(ViewListeTiersCriteresModel criteres)
        {
            IEnumerable<ViewListeTiers> listeTiers = new List<ViewListeTiers>();

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(string.Format("{0}{1}{2}",
                                                this._optionsAPI.BaseUrl,
                                                this._optionsAPI.UrlViewListeTiers,
                                                criteres.ToUriComponent()));

                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        listeTiers     = JsonConvert.DeserializeObject<IEnumerable<ViewListeTiers>>(content);
                    }
                }
            }

            return listeTiers; 
        }       
    }
}