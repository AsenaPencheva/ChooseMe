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
    public class AdoptionFormController : Controller
    {
        private IAdoptionFormService adoptionForms;
        private IAnimalService animals;
        private IAdopterService adopters;
        protected ISanitizer sanitizeService;

        public AdoptionFormController(IAdoptionFormService adoptionForms, IAnimalService animals, IAdopterService adopters, ISanitizer sanitizeService)
        {
            this.adoptionForms = adoptionForms;
            this.animals = animals;
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
        public ActionResult Create(CreateAdoptionFormViewModel model, int id)
        {
            if (model != null && ModelState.IsValid)
            {
                model.AnimalsDescription = this.sanitizeService.Sanitize(model.AnimalsDescription);

                model.ExpirienceWithAnimals = this.sanitizeService.Sanitize(model.ExpirienceWithAnimals);

                model.KidsDescription = this.sanitizeService.Sanitize(model.KidsDescription);

                model.Address = this.sanitizeService.Sanitize(model.Address);

                model.AttitudeAboutCastration = this.sanitizeService.Sanitize(model.AttitudeAboutCastration);

                var newAdoptionForm = AutoMapper.Mapper.Map<AdoptionForm>(model);

                newAdoptionForm.AnimalId = id;

                newAdoptionForm.Animal = animals.GetById(id).FirstOrDefault();
               
                newAdoptionForm.UserId = this.User.Identity.GetUserId();

                newAdoptionForm.User = adopters.GetById(newAdoptionForm.UserId).FirstOrDefault();

                this.adoptionForms.AddNew(newAdoptionForm);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return this.View(model);
            }
        }
    }
}