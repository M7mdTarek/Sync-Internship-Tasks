using Microsoft.AspNetCore.Mvc;

namespace Sync_Task1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
