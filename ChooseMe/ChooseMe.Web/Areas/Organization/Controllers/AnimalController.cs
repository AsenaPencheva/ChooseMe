namespace ChooseMe.Web.Areas.Organization.Controllers
{
    using ChooseMe.Models;
    using Microsoft.AspNet.Identity;
    using Models.Animal;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AnimalController:Controller
    {
        private IAnimalService animals;
        private IOrganizationService organizations;

        public AnimalController(IAnimalService animals, IOrganizationService organizations)
        {
            this.animals = animals;
            this.organizations = organizations;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newAnimal = AutoMapper.Mapper.Map<Animal>(model);

                newAnimal.OrganizationId = this.User.Identity.GetUserId();

                newAnimal.Organization = organizations.GetById(newAnimal.OrganizationId).FirstOrDefault();

                newAnimal.AddedOn = DateTime.UtcNow;

                var result = this.animals.AddNew(newAnimal);

                return this.RedirectToAction("Upload", "Photo", new { area = "Organization", id = result.Id, animal = newAnimal });
            }

            return this.View(model);
        }
    }
}