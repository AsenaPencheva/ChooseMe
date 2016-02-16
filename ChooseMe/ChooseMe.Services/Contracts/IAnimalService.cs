namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IAnimalService
    {
        IQueryable<Animal> GetAll();

        IQueryable<Animal> GetAllCats();

        IQueryable<Animal> GetAllDogs();

        IQueryable<Animal> GetLatestCats(int number);

        IQueryable<Animal> GetLatestDogs(int number);

        IQueryable<Animal> GetAllByOrganizationId(string id);

        IQueryable<Animal> GetById(int id);

        Animal AddNew(Animal animal);

        IQueryable<Animal> UpdateAnimal(Animal updatedAnimal);

        void DeleteAnimal(int id);
    }
}
