namespace ChooseMe.Web.Areas.Adopter.Controllers
{
    using ChooseMe.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    public class VolunteerFormController : Controller
    {
        private IVolunteerFormService volunteers;
        private IOrganizationService organizations;
        private IAdopterService adopters;

        public VolunteerFormController(IVolunteerFormService volunteers, IOrganizationService organizations, IAdopterService adopters)
        {
            this.volunteers = volunteers;
            this.organizations = organizations;
            this.adopters = adopters;
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