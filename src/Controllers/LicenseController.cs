using System;
using Microsoft.AspNet.Mvc;
using LicenseManager.Models;
using LicenseManager.ViewModels;
using LicenseManager.Database;

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
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody]ClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                licenseManagerDbContext.Clients.Add(client);
                licenseManagerDbContext.SaveChanges();
            }

            return Json(Url.Action("Index", "License"));
        }
    }
}