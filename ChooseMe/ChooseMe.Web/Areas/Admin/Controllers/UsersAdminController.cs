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
    public class UsersAdminController:Controller
    {
        private IUserService users;

        public UsersAdminController(IUserService users)
        {
            this.users = users;
        }

        public ActionResult Delete(string id)
        {
            this.users.DeleteUser(id);
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

            var result = users.GetAll().ProjectTo<UsersListView>();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result
                .Where(a => a.UserName.ToLower().Contains(searchString.ToLower()));
            }

            int pageNumber = (page ?? 1);
            var sorted = this.Sorted(result, sortOrder);
            return View(sorted.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        private IQueryable<UsersListView> Sorted(IQueryable<UsersListView> all, string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
                case "Name":
                    all = all.OrderBy(a => a.UserName);
                    break;
                case "name_desc":
                    all = all.OrderByDescending(a => a.UserName);
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