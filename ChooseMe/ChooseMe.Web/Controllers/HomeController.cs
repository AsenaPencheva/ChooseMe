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
    public class HomeController : Controller
    {
        private IAnimalService animals;

        private IOrganizationService organizations;

        public HomeController(IAnimalService animals, IOrganizationService organizations)
        {
            this.animals = animals;
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLastCats()
        {
            var cats = animals.GetLatestCats(ControllersConst.TopAnimalsNumber).ProjectTo<AnimalsListView>();
            return this.PartialView("_LatestAnimals", cats);
        }

        public ActionResult GetLastDogs()
        {
            var dogs = animals.GetLatestDogs(ControllersConst.TopAnimalsNumber).ProjectTo<AnimalsListView>();
            return this.PartialView("_LatestAnimals", dogs);
        }

        public ActionResult GetOrganizationWithMostAnimals()
        {
            var orgs = organizations.OrganizationWithMostAnimals(ControllersConst.TopOrganizationsNumber).ProjectTo<OrganizationsListView>();
            return this.PartialView("_OrgsMostAnimals", orgs);
        }
    }
}