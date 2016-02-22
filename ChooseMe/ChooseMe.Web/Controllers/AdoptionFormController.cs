namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Forms;
    using Services.Contracts;
    using System.Web.Mvc;

    public class AdoptionFormController:Controller
    {
        private IAdoptionFormService adoptionForms;

        public AdoptionFormController(IAdoptionFormService adoptionForms)
        {
            this.adoptionForms = adoptionForms;
        }

         public ActionResult AllByAdopter(string id)
        {
            var forms = adoptionForms.GetAllByUserId(id).ProjectTo<AdoptionFormsAdopterListViewModel>();
            return this.PartialView("_AllAdoptersAFView", forms);
        }

        public ActionResult AllByAnimal(int id)
        {
            var forms = adoptionForms.GetAllByAnimalId(id).ProjectTo<FormsListView>();
            return this.PartialView("_All", forms);
        }
    }
}