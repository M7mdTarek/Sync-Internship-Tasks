using Microsoft.AspNetCore.Mvc;

namespace Sync_Task3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
