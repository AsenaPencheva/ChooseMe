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
    using System;
    public class AnimalsController:Controller
    {
        [Inject]
        public IAnimalService AnimalService { get; set; }

        public ActionResult All(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
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

            var sorted = this.Sorted(result, sortOrder);

            return View(sorted.ToPagedList(pageNumber, ControllersConst.PageSize));
        }

        private IQueryable<AnimalsListView> Sorted(IQueryable<AnimalsListView> all, string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
                case "Age":
                    all = all.OrderBy(a => a.DateOfBirth);
                    break;
                case "age_desc":
                    all = all.OrderByDescending(a => a.DateOfBirth);
                    break;
                case "Name":
                    all = all.OrderBy(a => a.Name);
                    break;
                case "name_desc":
                    all = all.OrderByDescending(a => a.Name);
                    break;
                case "Date":
                    all = all.OrderByDescending(a => a.AddedOn);
                    break;
                default:
                    all = all.OrderBy(a => a.AddedOn);
                    break;
            }

            return all;
        }
    }
}