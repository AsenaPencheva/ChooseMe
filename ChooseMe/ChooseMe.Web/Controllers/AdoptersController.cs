namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Adopter;
    using Ninject;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class AdoptersController:Controller
    {
        private IAdopterService adopters;

        public AdoptersController(IAdopterService adopters)
        {
            this.adopters = adopters;
        }

        public ActionResult Details(string id)
        {
            var adopter = adopters.GetById(id)
                .ProjectTo<AdopterDetailView>()
                .FirstOrDefault();

            return View(adopter);
        }
    }
}