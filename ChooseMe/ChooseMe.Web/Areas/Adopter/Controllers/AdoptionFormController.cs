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

        public AdoptionFormController(IAdoptionFormService adoptionForms, IAnimalService animals, IAdopterService adopters)
        {
            this.adoptionForms = adoptionForms;
            this.animals = animals;
            this.adopters = adopters;
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