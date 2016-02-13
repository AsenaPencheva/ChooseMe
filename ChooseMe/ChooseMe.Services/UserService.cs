namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public void DeleteUser(string id)
        {
            this.users.Delete(id);

            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users
                .All()
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<User> UpdateUser(User updatedUser)
        {
            this.users.Update(updatedUser);
            this.users.SaveChanges();

            return this.users
                .All()
                .Where(r => r.Id == updatedUser.Id);
        }

        public User GetUser(string name)
        {
            var userAsObject = this.users
               .All()
               .Where(x => x.UserName == name)
               .FirstOrDefault();

            return userAsObject;
        }
    }
}
