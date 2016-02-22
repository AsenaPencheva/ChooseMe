﻿namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Models.Forms;
    using PagedList;
    using Services.Contracts;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class VolunteersFormController:Controller
    {
        private IVolunteerFormService volunteerForms;

        public VolunteersFormController(IVolunteerFormService volunteerForms)
        {
            this.volunteerForms = volunteerForms;
        }

        public ActionResult AllByAdopter(string id)
        {
            var forms =  volunteerForms.GetAllByAdopterId(id).ProjectTo<VolunteerFormsAdopterListViewModel>();
            return this.PartialView("_AllAdoptersVFView", forms);
        }

        public ActionResult AllByOrganization(int? page)
        {

            int pageNumber = (page ?? 1);

            var result = this.volunteerForms.GetAllByOrganizationId(User.Identity.GetUserId()).ProjectTo<FormsListView>();
            return this.PartialView("_AllFormOrganizationView", result.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        public ActionResult ListViewForms()
        {
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            this.volunteerForms.DeleteVolunteerForm(id);
            return this.View("ListViewForms");
        }
    }
}
