namespace ChooseMe.Services.Contracts
{
    using ChooseMe.Models;
    using System.Linq;

    public interface IOrganizationService
    {
        IQueryable<Organization> GetAll();

        IQueryable<Organization> GetById(string id);

        IQueryable<Organization> UpdateOrganization(Organization updatedOrganization, Organization currentOrganization);

        void DeleteOrganization(string id);

        IQueryable<Organization> OrganizationWithMostAnimals(int number);
    }
}