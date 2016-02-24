namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        void DeleteUser(string id);
    }
}
