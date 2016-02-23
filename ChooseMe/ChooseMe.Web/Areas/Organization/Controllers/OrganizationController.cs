namespace ChooseMe.Web.Areas.Organization.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.Organization;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ChooseMe.Models;
    using Common.Constants;
    [Authorize(Roles = ControllersConst.OrganizationRole)]
    public class OrganizationController:Controller
    {
        private IOrganizationService organizations;

        public  OrganizationController(IOrganizationService organizations)
        {
            this.organizations = organizations;
        }

        [HttpGet]
        public ActionResult Update()
        {
            var id = this.User.Identity.GetUserId();
            var user = organizations.GetById(id);
            var model = user.ProjectTo<OrganizationProfileViewModel>().FirstOrDefault();
            model.CreatedOn = user.FirstOrDefault().CreatedOn;
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(OrganizationProfileViewModel updated)
        {
            if (updated != null && ModelState.IsValid)
            {
                updated.Id = this.User.Identity.GetUserId();
                var user = organizations.GetById(updated.Id).FirstOrDefault();
                var result = Mapper.Map<Organization>(updated);
                var updatedResult = organizations.UpdateOrganization(result, user);
                return this.View(Mapper.Map<OrganizationProfileViewModel>(updated));
            }
            return this.View(updated);
        }
    }
}