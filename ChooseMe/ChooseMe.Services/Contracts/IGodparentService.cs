namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IGodparentService
    { 
        IQueryable<Godparent> GetAllByAnimalId(int animalId);

        Godparent GetById(int id);

        Godparent AddNew(Godparent godparent);

        void DeleteGodparent(int id);
    }
}