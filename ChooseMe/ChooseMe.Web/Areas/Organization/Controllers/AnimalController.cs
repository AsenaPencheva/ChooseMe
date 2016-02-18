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

                return this.RedirectToAction("Upload", "Animal", new { area = "Organization", id = result.Id, animal = newAnimal });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(CreateViewModel model, int id, Animal animal)
        {
            foreach (var file in model.Files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    var photo = new Photo();
                    photo.Address = path;
                    photo.AnimalId = id;
                    photo.Animal = animal;
                    animal.Photos.Add(photo);

                    return this.RedirectToAction("Details", "Animasl", new { area = "", id = id });
                }
            }
            return this.View(model);
        }
    }
}