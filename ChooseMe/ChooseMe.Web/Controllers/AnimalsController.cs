namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Animal;
    using Ninject;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using PagedList;
    using Common.Constants;
    public class AnimalsController:Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public ActionResult All(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var result = AnimalService.GetAll().ProjectTo<AnimalsListView>();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result
                .Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }

            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, ControllersConst.PageSize));
        }
    }
}