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
    public class ViewListeTiersController : ControllerBase
    {
        private readonly AudeebleContextDB _context;

        public ViewListeTiersController(AudeebleContextDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Liste des tiers.
        /// </summary>
        /// <param name="inclureArchive">Inclure les tiers marqués comme archivés.</param>
        /// <param name="inclurePersPhysique">Inclure les personnes physiques.</param>
        /// <param name="inclurePersMorale">Inclure les personnes morales.</param>
        /// <returns>Liste des tiers correspondant aux critères de la recherche.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewListeTiers>>> GetTiers(
               bool inclureArchive,
               bool inclurePersPhysique,
               bool inclurePersMorale)
        {
            IQueryable<ViewListeTiers> query = this._context.Tiers.AsQueryable<ViewListeTiers>();

            // Ne pas récupérer les tiers archivés
            if (!inclureArchive)
            {
                query = query.Where(x => x.EstArchive.Equals(false));
            }

            // Ne pas récupérer les personnes physiques ou morales
            if ((inclurePersMorale && !inclurePersPhysique) || (!inclurePersMorale && inclurePersPhysique))
            {
                if (!inclurePersPhysique)
                {
                    query = query.Where(x => x.EstPersonnePhysique.Equals(false));
                }

                if (!inclurePersMorale)
                {
                    query = query.Where(x => x.EstPersonnePhysique.Equals(true));
                }
            }

            // Exécution et retour
            return await query.ToListAsync();
        }
    }
}