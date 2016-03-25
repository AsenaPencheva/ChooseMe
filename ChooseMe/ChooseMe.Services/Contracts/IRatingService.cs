namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IRatingService
    {
        double GetAverage();

        IQueryable<Rating> GetByUserAndOrganizationId(string id, string orgId);

        Rating AddNew(Rating rating);
    }
}
