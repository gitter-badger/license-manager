using Microsoft.AspNet.Mvc;

namespace LicenseManager.Controllers
{
    public class LicenseTemplateController : Controller
    {
        public LicenseTemplateController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}