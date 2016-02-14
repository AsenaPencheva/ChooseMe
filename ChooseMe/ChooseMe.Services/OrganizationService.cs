namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> organization;

        public OrganizationService(IRepository<Organization> organization)
        {
            this.organization = organization;
        }

        public void DeleteOrganization(string id)
        {
            this.organization.Delete(id);

            this.organization.SaveChanges();
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organization.All();
        }

        public Organization GetById(string id)
        {
            return this.organization
                .All()
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Organization> UpdateOrganization(Organization updatedOrganization)
        {
            this.organization.Update(updatedOrganization);
            this.organization.SaveChanges();

            return this.organization
                .All()
                .Where(r => r.Id == updatedOrganization.Id);
        }

        public IQueryable<Organization> OrganizationWithMostAnimals(int number)
        {
            return this.organization
                .All()
                .OrderByDescending(o => o.Animals.Count())
                .Take(number);
        }
    }
}