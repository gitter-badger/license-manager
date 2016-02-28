using Microsoft.AspNet.Mvc;

namespace LicenseManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}