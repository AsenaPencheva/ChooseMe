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
            return this.organization
                .All()
                .OrderByDescending(o => o.CreatedOn); 
        }

        public IQueryable<Organization> GetById(string id)
        {
            return this.organization
                .All()
                .Where(o => o.Id == id);
        }

        public IQueryable<Organization> UpdateOrganization(Organization updatedOrganization, Organization currentOrganization)
        {
            if (updatedOrganization.Name != currentOrganization.Name)
            {
                currentOrganization.Name = updatedOrganization.Name;
            }
            if (updatedOrganization.Description != currentOrganization.Description)
            {
                currentOrganization.Description = updatedOrganization.Description;
            }
            if (updatedOrganization.Email != currentOrganization.Email)
            {
                currentOrganization.Email = updatedOrganization.Email;
            }
            if (updatedOrganization.ImageURL != currentOrganization.ImageURL)
            {
                currentOrganization.ImageURL = updatedOrganization.ImageURL;
            }

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