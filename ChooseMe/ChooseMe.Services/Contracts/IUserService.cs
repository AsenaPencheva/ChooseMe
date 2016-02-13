namespace ChooseMe.Services.Contracts
{
    using ChooseMe.Models;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        IQueryable<User> UpdateUser(User updatedUser);

        void DeleteUser(string id);

        User GetUser(string name);
    }
}