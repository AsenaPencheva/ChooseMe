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
    using Common.Enums;
    using System.Net;

    public class AnimalsController:Controller
    {
        private IAnimalService animals;

        public AnimalsController(IAnimalService animals)
        {
            this.animals = animals;
        }

        [HttpGet]
        public ActionResult All(string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Type = type;

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
            var filtered = this.Filtered(sorted, type);
            return View(filtered.ToPagedList(pageNumber, ControllersConst.PageSize));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var animal = animals
                .GetById(id)
                .ProjectTo<AnimalDetailView>()
                .FirstOrDefault();

            if (animal == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }

            return View(animal);
        }

        private IQueryable<AnimalsListView> Filtered(IQueryable<AnimalsListView> all, string type)
        {
            var filteredAnimals = all;

            switch (type)
            {
                case "Dog":
                    filteredAnimals = filteredAnimals.Where(a => a.Type == AnimalType.Dog);
                    break;
                case "Cat":
                    filteredAnimals = filteredAnimals.Where(a => a.Type == AnimalType.Cat);
                    break;
                case "Both":
                default:
                    break;
            }

            return filteredAnimals;
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