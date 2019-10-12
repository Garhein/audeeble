using Audeeble_Shared.Entity.Tiers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audeeble_API.Controllers
{
    [Route("api/[controller]")]
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
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewListeTiers>>> GetTiers()
        {
            return await _context.Tiers.ToListAsync();
        }
    }
}