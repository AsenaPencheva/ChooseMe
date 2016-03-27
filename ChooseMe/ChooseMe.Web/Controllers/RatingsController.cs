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
                model.Value = int.Parse(submit);

                model.UserId = User.Identity.GetUserId();

                if (this.ratings.CheckIfRate(model.UserId))
                {
                    this.ratings.Update(model.Value, model.UserId);
                }
                else
                {
                    model.OrganizationId = model.OrganizationId;

                    var newRating = Mapper.Map<Rating>(model);

                    this.ratings.AddNew(newRating);
                }

                return this.RedirectToAction("Details", "Organizations", new { area = "", id =  model.OrganizationId});
            }

            return new HttpStatusCodeResult(404);
        }

        [HttpGet]
        public ActionResult Average(string id)
        {
            return this.Content(this.ratings.GetAverage(id).ToString());
        }
    }
}