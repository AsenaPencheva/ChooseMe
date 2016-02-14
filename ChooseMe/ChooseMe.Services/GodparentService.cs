namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    public class GodparentService: IGodparentService
    {
        private readonly IRepository<Godparent> godparents;

        public GodparentService(IRepository<Godparent> godparents)
        {
            this.godparents = godparents;
        }

        public Godparent AddNew(Godparent godparent)
        {
            this.godparents.Add(godparent);

            this.godparents.SaveChanges();

            return godparent;
        }

        public void DeleteGodparent(int id)
        {
            this.godparents.Delete(id);

            this.godparents.SaveChanges();
        }

        public IQueryable<Godparent> GetAllByAnimalId(int animalId)
        {
            return this.godparents
                .All()
                .Where(g => g.AnimalId == animalId);
        }

        public Godparent GetById(int id)
        {
            return this.godparents
                .All()
                .Where(g => g.Id == id)
                .FirstOrDefault();
        }
    }
}
