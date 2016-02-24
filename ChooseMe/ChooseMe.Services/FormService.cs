namespace ChooseMe.Services
{
    using Contracts;
    using System.Linq;
    using Models;
    using System;
    using Data.Repositories;

    public class FormService : IFormService
    {
        private readonly IRepository<Form> forms;


        public FormService(IRepository<Form> forms)
        {
            this.forms = forms;
        }

        public void DeleteForm(int id)
        {
            this.forms.Delete(id);

            this.forms.SaveChanges();
        }

        public IQueryable<Form> GetAll()
        {
            return this.forms.All();
        }
    }
}
