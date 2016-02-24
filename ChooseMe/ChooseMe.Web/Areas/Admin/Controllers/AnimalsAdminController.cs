namespace ChooseMe.Web.Areas.Admin.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models;
    using PagedList;
    using Services.Contracts;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize(Roles = ControllersConst.AdminRole)]
    public class AnimalsAdminController : Controller
    {
        private IAnimalService animals;

        public AnimalsAdminController(IAnimalService animals)
        {
            this.animals = animals;
        }

        public ActionResult Delete(int id)
        {
            this.animals.DeleteAnimal(id);
            return this.RedirectToAction("All");
        }

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

            var result = animals.GetAll().ProjectTo<AnimalsListView>();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result
                .Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }

            int pageNumber = (page ?? 1);
            var sorted = this.Sorted(result, sortOrder);
            return View(sorted.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        private IQueryable<AnimalsListView> Sorted(IQueryable<AnimalsListView> all, string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
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