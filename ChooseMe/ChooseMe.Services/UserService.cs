namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    using Models;
    public class UserService :IUserService
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
    }
}
