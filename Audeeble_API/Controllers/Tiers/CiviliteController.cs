using Audeeble_Shared.Entity.Tiers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Audeeble_API.Controllers.Tiers
{
    [Route("api/tiers/[controller]")]
    [ApiController]
    public class CiviliteController : ControllerBase
    {
        private readonly AudeebleContextDB _context;

        public CiviliteController(AudeebleContextDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Liste des civilité.
        /// </summary>
        /// <param name="inclureArchive">Inclure les civilités marquées comme archivées.</param>
        /// <returns>Liste des civilité correspondant aux critères de la recherche.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Civilite>>> GetCivilite(bool inclureArchive)
        {
            IQueryable<Civilite> query = this._context.Civilites.AsQueryable<Civilite>();

            // Ne pas récupérer les civilités archivées
            if (!inclureArchive)
            {
                query = query.Where(x => x.EstArchive.Equals(false));
            }

            // Tri alphabétique
            query = query.OrderBy(x => x.Libelle);

            // Exécution et retour
            return await query.ToListAsync();
        }
    }
}