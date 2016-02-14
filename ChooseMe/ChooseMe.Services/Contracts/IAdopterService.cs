namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IAdopterService
    {
        IQueryable<Adopter> GetAll();

        Adopter GetById(string id);

        IQueryable<Adopter> UpdateAdopter(Adopter updatedAdopter);

        void DeleteAdopter(string id);
    }
}