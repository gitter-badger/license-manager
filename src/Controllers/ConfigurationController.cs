using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using LicenseManager.Database;
using LicenseManager.ViewModels.Configuration.Clients;
using LicenseManager.ViewModels.Configuration.Systems;
using LicenseManager.ViewModels.Configuration.SystemVersions;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace LicenseManager.Controllers
{
    [Route("konfiguracja")]
    public class ConfigurationController : Controller
    {
        private readonly LicenseManagerDbContext licenseManagerDbContext;

        public ConfigurationController(LicenseManagerDbContext licenseManagerDbContext)
        {
            this.licenseManagerDbContext = licenseManagerDbContext;
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
                    Rows = licenseManagerDbContext.Clients
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

                licenseManagerDbContext.Clients.Add(client);
                licenseManagerDbContext.SaveChanges();

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
                    Rows = licenseManagerDbContext.Systems
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

                licenseManagerDbContext.Systems.Add(system);
                licenseManagerDbContext.SaveChanges();

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
                    Rows = licenseManagerDbContext.SystemVersions
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
                    System = licenseManagerDbContext.Systems.Single(x => x.Id == Guid.Parse(viewModel.SystemId))
                };

                licenseManagerDbContext.SystemVersions.Add(systemVersion);
                licenseManagerDbContext.SaveChanges();

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
                licenseManagerDbContext.Systems
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