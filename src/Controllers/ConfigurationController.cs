using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            FillNavigationViewBag();

            return View();
        }

        [HttpGet]
        [Route("klienci")]
        public IActionResult Clients()
        {
            FillNavigationViewBag();

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
            FillNavigationViewBag();

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

            FillNavigationViewBag();

            return View(viewModel);
        }

        [HttpGet]
        [Route("klienci/modyfikuj/{id?}")]
        public IActionResult ModifyClient(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.Client client = dbContext.Clients
                .SingleOrDefault(x => x.Id == id);

            if (client != null && !client.Deleted)
            {
                FillNavigationViewBag();

                ModifyClientViewModel viewModel = mapper.Map<ModifyClientViewModel>(client);

                return View(viewModel);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("klienci/modyfikuj/{id?}")]
        public IActionResult ModifyClient(Guid? id, ModifyClientViewModel viewModel)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                Models.Client client = dbContext.Clients
                    .SingleOrDefault(x => x.Id == id);

                if (client != null)
                {
                    client.Name = viewModel.Name;
                    client.Description = viewModel.Description;

                    dbContext.SaveChanges();

                    return RedirectToAction("Clients");
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
            }

            FillNavigationViewBag();

            return View(viewModel);
        }

        [HttpDelete]
        [Route("klienci/usun/{id?}")]
        public IActionResult DeleteClient(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.Client client = dbContext.Clients
                .SingleOrDefault(x => x.Id == id);

            if (client != null)
            {
                client.Deleted = true;

                dbContext.SaveChanges();

                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("systemy")]
        public IActionResult Systems()
        {
            FillNavigationViewBag();

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
            FillNavigationViewBag();

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

            FillNavigationViewBag();

            return View(viewModel);
        }

        [HttpGet]
        [Route("systemy/modyfikuj/{id?}")]
        public IActionResult ModifySystem(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.System system = dbContext.Systems
                .SingleOrDefault(x => x.Id == id);

            if (system != null && !system.Deleted)
            {
                FillNavigationViewBag();

                ModifySystemViewModel viewModel = mapper.Map<ModifySystemViewModel>(system);

                return View(viewModel);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("systemy/modyfikuj/{id?}")]
        public IActionResult ModifySystem(Guid? id, ModifySystemViewModel viewModel)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                Models.System system = dbContext.Systems
                    .SingleOrDefault(x => x.Id == id);

                if (system != null)
                {
                    system.Name = viewModel.Name;
                    system.Description = viewModel.Description;

                    dbContext.SaveChanges();

                    return RedirectToAction("Systems");
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
            }

            FillNavigationViewBag();

            return View(viewModel);
        }

        [HttpDelete]
        [Route("systemy/usun/{id?}")]
        public IActionResult DeleteSystem(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.System system = dbContext.Systems
                .SingleOrDefault(x => x.Id == id);

            if (system != null)
            {
                system.Deleted = true;

                dbContext.SaveChanges();

                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("wersje-systemow")]
        public IActionResult SystemVersions()
        {
            FillNavigationViewBag();

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
            FillNavigationViewBag();

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
                systemVersion.System = dbContext.Systems
                    .Single(x => x.Id == systemId);

                dbContext.SystemVersions.Add(systemVersion);

                dbContext.SaveChanges();

                return RedirectToAction("SystemVersions");
            }

            FillNavigationViewBag();

            ViewBag.SystemSelectListItems = GetSystemSelectListItems();

            return View(viewModel);
        }

        [HttpGet]
        [Route("wersje-systemow/modyfikuj/{id?}")]
        public IActionResult ModifySystemVersion(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.SystemVersion systemVersion = dbContext.SystemVersions
                .SingleOrDefault(x => x.Id == id);

            if (systemVersion != null && !systemVersion.Deleted)
            {
                FillNavigationViewBag();

                ViewBag.SystemSelectListItems = GetSystemSelectListItems();

                ModifySystemVersionViewModel viewModel = mapper.Map<ModifySystemVersionViewModel>(systemVersion);

                return View(viewModel);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("wersje-systemow/modyfikuj/{id?}")]
        public IActionResult ModifySystemVersion(Guid? id, ModifySystemVersionViewModel viewModel)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                Models.SystemVersion systemVersion = dbContext.SystemVersions
                    .SingleOrDefault(x => x.Id == id);

                if (systemVersion != null)
                {
                    systemVersion.Major = int.Parse(viewModel.Major);
                    systemVersion.Minor = int.Parse(viewModel.Minor);
                    systemVersion.Description = viewModel.Description;

                    Guid systemId = Guid.Parse(viewModel.SystemId);
                    systemVersion.System = dbContext.Systems
                        .Single(x => x.Id == systemId);

                    dbContext.SaveChanges();

                    return RedirectToAction("SystemVersions");
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
            }

            FillNavigationViewBag();

            return View(viewModel);
        }

        [HttpDelete]
        [Route("wersje-systemow/usun/{id?}")]
        public IActionResult DeleteSystemVersion(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            Models.SystemVersion systemVersion = dbContext.SystemVersions
                .SingleOrDefault(x => x.Id == id);

            if (systemVersion != null)
            {
                systemVersion.Deleted = true;

                dbContext.SaveChanges();

                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        private void FillNavigationViewBag()
        {
            ViewBag.NonDeletedClientsCount = GetNonDeletedClientsCount();
            ViewBag.NonDeletedSystemsCount = GetNonDeletedSystemsCount();
            ViewBag.NonDeletedSystemVersionsCount = GetNonDeletedSystemVersionsCount();
        }

        private int GetNonDeletedClientsCount()
        {
            return dbContext.Clients
                .Count(x => !x.Deleted);
        }

        private int GetNonDeletedSystemsCount()
        {
            return dbContext.Systems
                .Count(x => !x.Deleted);
        }

        private int GetNonDeletedSystemVersionsCount()
        {
            return dbContext.SystemVersions
                .Count(x => !x.Deleted);
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