namespace ChooseMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;

    using Ninject;
    using Services.Contracts;
    using Models.Animal;
    using Models.Organization;
    public class HomeController : Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        [Inject]
        public IOrganizationService OrganizationService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLastCats()
        {
            var cats = AnimalService.GetLatestCats(5).ProjectTo<AnimalsListView>();
            return this.PartialView("_LatestAnimals", cats);
        }

        public ActionResult GetLastDogs()
        {
            var dogs = AnimalService.GetLatestDogs(5).ProjectTo<AnimalsListView>();
            return this.PartialView("_LatestAnimals", dogs);
        }

        public ActionResult GetOrganizationWithMostAnimals()
        {
            var orgs = OrganizationService.OrganizationWithMostAnimals(10).ProjectTo<OrganizationListView>();
            return this.PartialView("_OrgsMostAnimals", orgs);
        }
    }
}