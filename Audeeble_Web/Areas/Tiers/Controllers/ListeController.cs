using Microsoft.AspNetCore.Mvc;

namespace Audeeble_Web.Areas.Tiers.Controllers
{
    [Area("Tiers")]
    [Route("Tiers/[controller]")]
    public class ListeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}