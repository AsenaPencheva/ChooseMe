namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> ratings;

        public RatingService(IRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public Rating AddNew(Rating rating)
        {
            this.ratings.Add(rating);

            this.ratings.SaveChanges();

            return rating;
        }

        public double GetAverage()
        {
            var sum = 0;

            foreach(var rating in ratings.All())
            {
                sum += rating.Value;
            }

            return sum / ratings.All().Count();
        }

        public IQueryable<Rating> GetByUserAndOrganizationId(string id, string orgId)
        {
            return this.ratings
                .All()
                .Where(r => r.OrganizationId == orgId && r.UserId == id);
        }
    }
}
