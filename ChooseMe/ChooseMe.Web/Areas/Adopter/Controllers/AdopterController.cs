namespace ChooseMe.Web.Areas.Adopter.Controllers
{
    using Models;
    using Services.Contracts;
    using System.Web.Mvc;
    using ChooseMe.Models;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using AutoMapper;
    public class AdopterController:Controller
    {
        private IAdopterService adopters;

        public AdopterController(IAdopterService adopters)
        {
            this.adopters = adopters;
        }

        [HttpGet]
        public ActionResult Profile()
        {
            var id = this.User.Identity.GetUserId();
            var user = adopters.GetById(id);
            var model = user.ProjectTo<AdopterProfileViewModel>().FirstOrDefault();
            model.CreatedOn = user.FirstOrDefault().CreatedOn;
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(AdopterProfileViewModel updated)
        {
            if (updated != null && ModelState.IsValid)
            {
                updated.Id = this.User.Identity.GetUserId();
                var user = adopters.GetById(updated.Id).FirstOrDefault();
                var result = Mapper.Map<Adopter>(updated);
                var updatedResult = adopters.UpdateAdopter(result, user);
                return this.View(Mapper.Map<AdopterProfileViewModel>(updated));
            }
            return this.View(updated);
        }
    }
}