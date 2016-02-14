namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Animal;
    using Ninject;
    using Services.Contracts;
    using System.Web.Mvc;

    public class AnimalsController:Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public ActionResult All()
        {
            var animals = AnimalService.GetAll().ProjectTo<AnimalsListView>();
            return View(animals);
        }
    }
}