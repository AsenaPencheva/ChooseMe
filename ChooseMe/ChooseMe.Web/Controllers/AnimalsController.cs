namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Animal;
    using Ninject;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class AnimalsController:Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public ActionResult All(string searchString)
        {
            var result = AnimalService.GetAll().ProjectTo<AnimalsListView>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = result
                .Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }
            return View(result);
        }
    }
}