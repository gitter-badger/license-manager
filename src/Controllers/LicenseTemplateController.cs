using System;
using AutoMapper;
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
        private readonly IMapper mapper;

        public LicenseTemplateController(
            LicenseManagerDbContext dbContext,
            ILogger<LicenseTemplateController> logger,
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