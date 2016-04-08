using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LicenseManager.Database;
using LicenseManager.ViewModels.Configuration.Clients;
using LicenseManager.ViewModels.Configuration.Systems;
using LicenseManager.ViewModels.Configuration.SystemVersions;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;

namespace LicenseManager.Controllers
{
    [Route("konfiguracja")]
    public class ConfigurationController : Controller
    {
        private readonly LicenseManagerDbContext dbContext;
        private readonly ILogger<ConfigurationController> logger;
        private readonly IMapper mapper;

        public ConfigurationController(
            LicenseManagerDbContext dbContext,
            ILogger<ConfigurationController> logger,
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

        [HttpGet]
        [Route("klienci")]
        public IActionResult Clients()
        {
            ClientsViewModel viewModel = mapper.Map<ClientsViewModel>(
                dbContext.Clients
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            );

            return View(viewModel);
        }

        [HttpGet]
        [Route("klienci/stworz")]
        public IActionResult CreateClient()
        {
            CreateClientViewModel viewModel = new CreateClientViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("klienci/stworz")]
        public IActionResult CreateClient(CreateClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Models.Client client = mapper.Map<Models.Client>(viewModel);

                dbContext.Clients.Add(client);
                dbContext.SaveChanges();

                return RedirectToAction("Clients");
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("systemy")]
        public IActionResult Systems()
        {
            SystemsViewModel viewModel = mapper.Map<SystemsViewModel>(
                dbContext.Systems
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            );

            return View(viewModel);
        }

        [HttpGet]
        [Route("systemy/stworz")]
        public IActionResult CreateSystem()
        {
            CreateSystemViewModel viewModel = new CreateSystemViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("systemy/stworz")]
        public IActionResult CreateSystem(CreateSystemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Models.System system = mapper.Map<Models.System>(viewModel);

                dbContext.Systems.Add(system);
                dbContext.SaveChanges();

                return RedirectToAction("Systems");
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("wersje-systemow")]
        public IActionResult SystemVersions()
        {
            SystemVersionsViewModel viewModel = mapper.Map<SystemVersionsViewModel>(
                dbContext.SystemVersions
                    .Include(x => x.System)
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            );

            return View(viewModel);
        }

        [HttpGet]
        [Route("wersje-systemow/stworz")]
        public IActionResult CreateSystemVersion()
        {
            ViewBag.SystemSelectListItems = GetSystemSelectListItems();

            CreateSystemVersionViewModel viewModel = new CreateSystemVersionViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("wersje-systemow/stworz")]
        public IActionResult CreateSystemVersion(CreateSystemVersionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Models.SystemVersion systemVersion = mapper.Map<Models.SystemVersion>(viewModel);

                Guid systemId = Guid.Parse(viewModel.SystemId);
                systemVersion.System = dbContext.Systems.Single(x => x.Id == systemId);

                dbContext.SystemVersions.Add(systemVersion);
                dbContext.SaveChanges();

                return RedirectToAction("SystemVersions");
            }

            ViewBag.SystemSelectListItems = GetSystemSelectListItems();

            return View(viewModel);
        }

        private List<SelectListItem> GetSystemSelectListItems()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem()
            {
                Text = "Wybierz system..",
                Value = ""
            });

            result.AddRange(
                dbContext.Systems
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    })
            );

            return result;
        }
    }
}