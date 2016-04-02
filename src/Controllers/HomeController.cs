using System;
using LicenseManager.Database;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace LicenseManager.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly LicenseManagerDbContext dbContext;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            LicenseManagerDbContext dbContext,
            ILogger<HomeController> logger
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