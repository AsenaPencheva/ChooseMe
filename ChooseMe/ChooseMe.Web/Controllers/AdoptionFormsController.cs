namespace ChooseMe.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Forms;
    using PagedList;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class AdoptionFormsController:Controller
    {
        private IAdoptionFormService adoptionForms;

        public AdoptionFormsController(IAdoptionFormService adoptionForms)
        {
            this.adoptionForms = adoptionForms;
        }

        [Authorize(Roles = ControllersConst.AdopterRole)]
        public ActionResult AllByAdopter(string id, int? page)
        {
            int pageNumber = (page ?? 1);
            var forms = adoptionForms.GetAllByUserId(id).ProjectTo<AdoptionFormsAdopterListViewModel>();
            return this.PartialView("_AllAdoptersAFView", forms.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        [Authorize]
        public ActionResult ListViewAdoptionForms(string id)
        {
            return this.View(model: id);
        }

        [Authorize(Roles = ControllersConst.OrganizationRole)]
        public ActionResult AllByAnimal(string id, int? page)
        {
            int idInt = int.Parse(id);
            int pageNumber = (page ?? 1);
            var result = adoptionForms.GetAllByAnimalId(idInt).ProjectTo<FormsListView>();
            return this.PartialView("_AllFormOrganizationView", result.ToPagedList(pageNumber, ControllersConst.PageSizeOrg));
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            this.adoptionForms.DeleteAdoptionForm(id);
            return this.View("ListViewAdoptionForms");
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var form = this.adoptionForms
                .GetById(id)
                .ProjectTo<AdoptionFormDetailViewModel>()
                .FirstOrDefault();
            return this.View(form);
        }

    }
}