using Microsoft.AspNet.Mvc;

namespace LicenseManager.Controllers
{
    [Route("szablony-licencji")]
    public class LicenseTemplateController : Controller
    {
        public LicenseTemplateController()
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