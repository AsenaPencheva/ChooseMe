namespace ChooseMe.Web.Controllers
{
    using AutoMapper;
    using ChooseMe.Models;
    using Microsoft.AspNet.Identity;
    using Models.Rating;
    using Services.Contracts;
    using System;
    using System.Web.Mvc;

    public class RatingsController : Controller
    {
        IRatingService ratings;

        public RatingsController(IRatingService ratings)
        {
            this.ratings = ratings;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(RateViewModel model, string submit)
        {
            if (submit != null)
            {
                var rating = new RateViewModel();

                rating.Value = int.Parse(submit);

                rating.UserId = User.Identity.GetUserId();

                rating.OrganizationId = model.OrganizationId;

                var newRating = Mapper.Map<Rating>(rating);

                this.ratings.AddNew(newRating);

                return this.RedirectToAction("Details", "Organizations", new { area = "", id =  model.OrganizationId});
            }

            return new HttpStatusCodeResult(404);
        }
    }
}