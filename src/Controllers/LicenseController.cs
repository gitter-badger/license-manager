using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using LicenseManager.Database;
using LicenseManager.ViewModels;

namespace LicenseManager.Controllers
{
    public class LicenseController : Controller
    {
        private readonly LicenseManagerDbContext licenseManagerDbContext;

        public LicenseController(LicenseManagerDbContext licenseManagerDbContext)
        {
            this.licenseManagerDbContext = licenseManagerDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Clients()
        {
            ClientsViewModel viewModel = new ClientsViewModel()
            {
                ClientsTable = new ClientsTableViewModel()
                {
                    Rows = licenseManagerDbContext.Clients
                        .OrderBy(x => x.Name)
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
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody]CreateClientFormViewModel viewModel)
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
            }

            return Json(Url.Action("Index", "License"));
        }

        [HttpGet]
        public IActionResult CreateSystem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSystem([FromBody]CreateSystemFormViewModel viewModel)
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
            }

            return Json(Url.Action("Index", "License"));
        }

        [HttpGet]
        public IActionResult CreateSystemVersion()
        {
            CreateSystemVersionViewModel viewModel = new CreateSystemVersionViewModel()
            {
                SystemDropDownList = new SystemDropDownListViewModel()
                {
                    Items = licenseManagerDbContext.Systems
                        .OrderBy(x => x.Name)
                        .Select(x => new SystemDropDownListItemViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateSystemVersion([FromBody]CreateSystemVersionFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Guid systemId = Guid.Parse(viewModel.SystemId);

                Models.SystemVersion systemVersion = new Models.SystemVersion()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Major = viewModel.Major,
                    Minor = viewModel.Minor,
                    Description = !string.IsNullOrEmpty(viewModel.Description) ? viewModel.Description : null,
                    System = licenseManagerDbContext.Systems.Single(x => x.Id == systemId)
                };

                licenseManagerDbContext.SystemVersions.Add(systemVersion);
                licenseManagerDbContext.SaveChanges();
            }

            return Json(Url.Action("Index", "License"));
        }
    }
}