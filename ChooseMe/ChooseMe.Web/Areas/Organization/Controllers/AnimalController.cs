namespace ChooseMe.Web.Areas.Organization.Controllers
{
    using AutoMapper.QueryableExtensions;
    using ChooseMe.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Models.Animal;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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
        public ActionResult Create(AnimalCreateViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newAnimal = AutoMapper.Mapper.Map<Animal>(model);

                newAnimal.OrganizationId = this.User.Identity.GetUserId();

                newAnimal.Organization = organizations.GetById(newAnimal.OrganizationId).FirstOrDefault();

                newAnimal.AddedOn = DateTime.UtcNow;

                var result = this.animals.AddNew(newAnimal);

                return this.RedirectToAction("Details", "Animals", new { area = "", id = result.Id});
            }

            return this.View(model);
        }

        public ActionResult Index()
        {
            var value = this.animals.GetAllByOrganizationId(User.Identity.GetUserId());
            return View(value);
        }


        public ActionResult AnimalsRead([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Animal> animalsNew = animals.GetAllByOrganizationId(User.Identity.GetUserId());
            DataSourceResult result = animalsNew.ToDataSourceResult(request, c => new MyAnimalsViewModel
            {
                Type = c.Type,
                Name = c.Name,
                Gender = c.Gender,
                AddedOn = c.AddedOn,
                DateOfBirth = c.DateOfBirth,
                Story = c.Story,
                Disease = c.Disease,
                IsKidsFriendly = c.IsKidsFriendly,
                IsDogsFriendly = c.IsDogsFriendly,
                IsCatsFriendly = c.IsCatsFriendly,
                FurColor = c.FurColor,
                IsLonghaired = c.IsLonghaired,
                IsCastraited = c.IsCastraited,
                IsVaccinated = c.IsVaccinated,
                IsChipped = c.IsChipped
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AnimalsUpdate([DataSourceRequest]DataSourceRequest request, MyAnimalsViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var updated = AutoMapper.Mapper.Map<Animal>(model);

                updated.OrganizationId = User.Identity.GetUserId();
                var updatedmodel = this.animals
                    .UpdateAnimal(updated)
                    .ProjectTo<MyAnimalsViewModel>()
                    .FirstOrDefault();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AnimalsDestroy([DataSourceRequest]DataSourceRequest request, MyAnimalsViewModel model)
        {
            this.animals.DeleteAnimal(model.Id);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}