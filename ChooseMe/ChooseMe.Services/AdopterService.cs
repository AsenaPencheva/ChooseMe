namespace ChooseMe.Services
{
    using ChooseMe.Common.Constants;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Web.Data;
    public class AdopterService : IAdopterService
    {
        private readonly IRepository<Adopter> adopters;
        private readonly IChooseMeDbContext dbContext;

        public AdopterService(IRepository<Adopter> adopters, IChooseMeDbContext dbContext)
        {
            this.adopters = adopters;
            this.dbContext = dbContext;
        }

        public void DeleteAdopter(string id)
        {
            this.adopters.Delete(id);

            this.adopters.SaveChanges();
        }

        public IQueryable<Adopter> GetAll()
        {
            return this.adopters.All().OrderByDescending(a => a.CreatedOn);
        }

        public IQueryable<Adopter> UpdateAdopter(Adopter updatedAdopter, Adopter user)
        {
            if (updatedAdopter.FirstName != user.FirstName)
            {
                user.FirstName = updatedAdopter.FirstName;
            }
            if (updatedAdopter.LastName != user.LastName)
            {
                user.LastName = updatedAdopter.LastName;
            }
            if (updatedAdopter.Email != user.Email)
            {
                user.Email = updatedAdopter.Email;
            }
            if (updatedAdopter.ImageURL != user.ImageURL)
            {
                user.ImageURL = updatedAdopter.ImageURL;
            }

            this.adopters.SaveChanges();

            return this.adopters
                .All()
                .Where(r => r.Id == updatedAdopter.Id);
        }

        public IQueryable<Adopter> GetById(string id)
        {
            return this.adopters
                .All()
                .Where(a => a.Id == id);
        }
    }
}