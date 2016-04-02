using System;
using LicenseManager.Database;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace LicenseManager.Controllers
{
    [Route("szablony-licencji")]
    public class LicenseTemplateController : Controller
    {
        private readonly LicenseManagerDbContext dbContext;
        private readonly ILogger<LicenseTemplateController> logger;
        
        public LicenseTemplateController(
            LicenseManagerDbContext dbContext,
            ILogger<LicenseTemplateController> logger
            )
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            this.dbContext = dbContext;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}