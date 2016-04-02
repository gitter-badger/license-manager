using System;
using System.Collections.Generic;
using System.Linq;
using LicenseManager.Database;
using LicenseManager.ViewModels.Configuration.Clients;
using LicenseManager.ViewModels.Configuration.Systems;
using LicenseManager.ViewModels.Configuration.SystemVersions;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace LicenseManager.Controllers
{
    [Route("konfiguracja")]
    public class ConfigurationController : Controller
    {
        private readonly LicenseManagerDbContext dbContext;
        private readonly ILogger<ConfigurationController> logger;

        public ConfigurationController(
            LicenseManagerDbContext dbContext,
            ILogger<ConfigurationController> logger
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

        [HttpGet]
        [Route("klienci")]
        public IActionResult Clients()
        {
            ClientsViewModel viewModel = new ClientsViewModel()
            {
                Table = new ClientsTableViewModel()
                {
                    Rows = dbContext.Clients
                        .OrderBy(x => x.CreationDate)
                        .Select(x => new ClientsTableRowViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description
                        })
                }
            };

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
                Models.Client client = new Models.Client()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Name = viewModel.Name,
                    Description = !string.IsNullOrEmpty(viewModel.Description) ? viewModel.Description : null
                };

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
            SystemsViewModel viewModel = new SystemsViewModel()
            {
                Table = new SystemsTableViewModel()
                {
                    Rows = dbContext.Systems
                        .OrderBy(x => x.CreationDate)
                        .Select(x => new SystemsTableRowViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description
                        })
                }
            };

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
                Models.System system = new Models.System()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Name = viewModel.Name,
                    Description = !string.IsNullOrEmpty(viewModel.Description) ? viewModel.Description : null
                };

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
            SystemVersionsViewModel viewModel = new SystemVersionsViewModel()
            {
                Table = new SystemVersionsTableViewModel()
                {
                    Rows = dbContext.SystemVersions
                        .OrderBy(x => x.CreationDate)
                        .Select(x => new SystemVersionsTableRowViewModel()
                        {
                            Id = x.Id,
                            Major = x.Major,
                            Minor = x.Minor,
                            Description = x.Description,
                            SystemName = x.System.Name
                        })
                }
            };

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
                Models.SystemVersion systemVersion = new Models.SystemVersion()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Major = int.Parse(viewModel.Major),
                    Minor = int.Parse(viewModel.Minor),
                    Description = !string.IsNullOrEmpty(viewModel.Description) ? viewModel.Description : null,
                    System = dbContext.Systems.Single(x => x.Id == Guid.Parse(viewModel.SystemId))
                };

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