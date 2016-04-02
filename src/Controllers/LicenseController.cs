using Microsoft.AspNet.Mvc;

namespace LicenseManager.Controllers
{
    [Route("licencje")]
    public class LicenseController : Controller
    {
        public LicenseController()
        {
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}