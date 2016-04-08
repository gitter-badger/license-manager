using System;
using AutoMapper;
using LicenseManager.Database;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace LicenseManager.Controllers
{
    [Route("licencje")]
    public class LicenseController : Controller
    {
        private readonly LicenseManagerDbContext dbContext;
        private readonly ILogger<LicenseController> logger;
        private readonly IMapper mapper;

        public LicenseController(
            LicenseManagerDbContext dbContext,
            ILogger<LicenseController> logger,
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