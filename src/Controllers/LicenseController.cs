using System;
using Microsoft.AspNet.Mvc;
using LicenseManager.Models;
using LicenseManager.ViewModels;

namespace LicenseManager.Controllers
{
    public class LicenseController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public LicenseController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
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
            Client client = new Client()
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            databaseContext.Clients.Add(client);
            databaseContext.SaveChanges();

            return Json(Url.Action("Index", "License"));
        }
    }
}