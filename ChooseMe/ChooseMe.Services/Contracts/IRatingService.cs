namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IRatingService
    {
        double GetAverage(string id);

        IQueryable<Rating> GetByUserAndOrganizationId(string id, string orgId);

        Rating AddNew(Rating rating);

        bool CheckIfRate(string id);

        void Update(int newRating, string stringId);
    }
}
