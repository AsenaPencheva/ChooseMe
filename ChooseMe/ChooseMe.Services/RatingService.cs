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

        public double GetAverage(string id)
        {
            double sum = 0;

            var ratingsOrg = ratings.All().Where(r => r.OrganizationId == id);

            foreach(var rating in ratingsOrg)
            {
                sum += Convert.ToDouble(rating.Value);
            }

            if (sum == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(sum / ratingsOrg.Count(), 2);
            }
        }

        public IQueryable<Rating> GetByUserAndOrganizationId(string id, string orgId)
        {
            return this.ratings
                .All()
                .Where(r => r.OrganizationId == orgId && r.UserId == id);
        }

        public void Update(int newRating, string userId)
        {
            Rating rating = this.ratings.All().Where(r => r.UserId == userId).FirstOrDefault();

            rating.Value = newRating;

            this.ratings.SaveChanges();
        }

        public bool CheckIfRate(string id)
        {
            if(this.ratings.All().Any(r => r.UserId == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
