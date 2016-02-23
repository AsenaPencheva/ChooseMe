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
    using Common.Constants;
    using Services;
    public class HomeController : Controller
    {
        private const int TimeForCache = (10 * 60);

        private IAnimalService animals;

        private IOrganizationService organizations;
        private ICacheService cacheService;

        public HomeController(IAnimalService animals, IOrganizationService organizations, ICacheService cacheService)
        {
            this.cacheService = cacheService;
            this.animals = animals;
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetLastCats()
        { 
            var cats = this.cacheService.Get("Cats", () => this.animals.GetLatestCats(ControllersConst.TopAnimalsNumber).ProjectTo<AnimalsListView>().ToList(), TimeForCache);
            return this.PartialView("_LatestAnimals", cats);
        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetLastDogs()
        {
            var dogs = this.cacheService.Get("Dogs", () => this.animals.GetLatestDogs(ControllersConst.TopAnimalsNumber).ProjectTo<AnimalsListView>().ToList(), TimeForCache);
            return this.PartialView("_LatestAnimals", dogs);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOrganizationWithMostAnimals()
        {
            var orgs = this.cacheService
                .Get("Organizations", () => this.organizations
                .OrganizationWithMostAnimals(ControllersConst.TopOrganizationsNumber)
                .ProjectTo<OrganizationsListView>().ToList(), TimeForCache);
            return this.PartialView("_OrgsMostAnimals", orgs);
        }
    }
}