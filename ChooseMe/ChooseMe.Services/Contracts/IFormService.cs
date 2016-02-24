namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IFormService
    {
        IQueryable<Form> GetAll();

        void DeleteForm(int id);
    }
}
