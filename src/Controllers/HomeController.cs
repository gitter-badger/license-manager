using System;
using AutoMapper;
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
        private readonly IMapper mapper;

        public HomeController(
            LicenseManagerDbContext dbContext,
            ILogger<HomeController> logger,
            IMapper mapper
            )
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}