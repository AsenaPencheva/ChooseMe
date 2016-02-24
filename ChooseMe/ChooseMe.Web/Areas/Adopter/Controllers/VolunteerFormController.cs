namespace ChooseMe.Web.Areas.Adopter.Controllers
{
    using ChooseMe.Models;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize(Roles = ControllersConst.AdopterRole)]
    public class VolunteerFormController : Controller
    {
        private IVolunteerFormService volunteers;
        private IOrganizationService organizations;
        private IAdopterService adopters;
        protected ISanitizer sanitizeService;

        public VolunteerFormController(IVolunteerFormService volunteers, IOrganizationService organizations, IAdopterService adopters, ISanitizer sanitizeService)
        {
            this.volunteers = volunteers;
            this.organizations = organizations;
            this.adopters = adopters;
            this.sanitizeService = sanitizeService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVolunteerFormViewModel model, string id)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Other = this.sanitizeService.Sanitize(model.Other);

                var newVolunteerForm = AutoMapper.Mapper.Map<VolunteerForm>(model);

                newVolunteerForm.OrganizationId = id;

                newVolunteerForm.Organization = organizations.GetById(id).FirstOrDefault();

                newVolunteerForm.UserId = this.User.Identity.GetUserId();

                newVolunteerForm.User = adopters.GetById(newVolunteerForm.UserId).FirstOrDefault();

                this.volunteers.AddNew(newVolunteerForm);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return this.View(model);
            }
        }
    }
}