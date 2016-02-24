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
    public class FormsAdminController:Controller
    {
        private IFormService forms;

        public FormsAdminController(IFormService forms)
        {
            this.forms = forms;
        }

        public ActionResult Delete(int id)
        {
            this.forms.DeleteForm(id);
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

            var result = forms.GetAll().ProjectTo<FormsListView>();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result
                .Where(a => a.Author.ToLower().Contains(searchString.ToLower()));
            }

            int pageNumber = (page ?? 1);
            var sorted = this.Sorted(result, sortOrder);
            return View(sorted.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        private IQueryable<FormsListView> Sorted(IQueryable<FormsListView> all, string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
                case "Name":
                    all = all.OrderBy(a => a.Author);
                    break;
                case "name_desc":
                    all = all.OrderByDescending(a => a.Author);
                    break;
                case "Date":
                    all = all.OrderByDescending(a => a.CreatedOn);
                    break;
                default:
                    all = all.OrderBy(a => a.CreatedOn);
                    break;
            }

            return all;
        }
    }
}