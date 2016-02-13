namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    class AdopterService : IAdopterService
    {
        private readonly IRepository<Adopter> adopters;

        public AdopterService(IRepository<Adopter> adopters)
        {
            this.adopters = adopters;
        }

        public void DeleteAdopter(string id)
        {
            this.adopters.Delete(id);

            this.adopters.SaveChanges();
        }

        public IQueryable<Adopter> GetAll()
        {
            return this.adopters.All();
        }

        public Adopter GetById(string id)
        {
            return this.adopters
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Adopter> UpdateAdopter(Adopter updatedAdopter)
        {
            this.adopters.Update(updatedAdopter);
            this.adopters.SaveChanges();

            return this.adopters
                .All()
                .Where(r => r.Id == updatedAdopter.Id);
        }
    }
}