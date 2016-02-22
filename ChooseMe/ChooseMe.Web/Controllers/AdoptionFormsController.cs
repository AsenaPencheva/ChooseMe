namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Forms;
    using PagedList;
    using Services.Contracts;
    using System.Web.Mvc;

    public class AdoptionFormsController:Controller
    {
        private IAdoptionFormService adoptionForms;

        public AdoptionFormsController(IAdoptionFormService adoptionForms)
        {
            this.adoptionForms = adoptionForms;
        }

         public ActionResult AllByAdopter(string id, int? page)
        {
            int pageNumber = (page ?? 1);
            var forms = adoptionForms.GetAllByUserId(id).ProjectTo<AdoptionFormsAdopterListViewModel>();
            return this.PartialView("_AllAdoptersAFView", forms.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }
         
        public ActionResult ListViewAdoptionForms(int id)
        {
            return this.View(id);
        }

        public ActionResult AllByAnimal(int id, int? page)
        {
            int pageNumber = (page ?? 1);
            var result = adoptionForms.GetAllByAnimalId(id).ProjectTo<FormsListView>();
            return this.PartialView("_AllFormOrganizationView", result.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        public ActionResult Delete(int id)
        {
            this.adoptionForms.DeleteAdoptionForm(id);
            return this.View("ListViewAdoptionForms");
        }
    }
}