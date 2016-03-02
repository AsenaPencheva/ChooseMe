namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetById(string id);

        void DeleteUser(string id);
    }
}
