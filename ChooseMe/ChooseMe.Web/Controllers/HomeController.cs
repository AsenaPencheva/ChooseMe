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

    public class HomeController : Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLast5Cats()
        {
            var cats = AnimalService.GetLatestCats(5).ProjectTo<LatestAnimalsViewModel>();
            return this.PartialView("_LatestAnimals", cats);
        }

        public ActionResult GetLast5Dogs()
        {
            var dogs = AnimalService.GetLatestDogs(5).ProjectTo<LatestAnimalsViewModel>();
            return this.PartialView("_LatestAnimals", dogs);
        }
    }
}