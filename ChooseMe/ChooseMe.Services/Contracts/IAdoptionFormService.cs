namespace ChooseMe.Services.Contracts
{
    using ChooseMe.Models;
    using System.Linq;

    public interface IAdoptionFormService
    {
        IQueryable<AdoptionForm> GetAllByAnimalId(int id);

        IQueryable<AdoptionForm> GetAllByUserId(string id);

        AdoptionForm GetById(int id);

        void AddNew(AdoptionForm form);

        void DeleteAdoptionForm(int id);
    }
}