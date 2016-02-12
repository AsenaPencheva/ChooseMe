namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IMessageService
    {
        IQueryable<Message> GetAllByUserId(string id);

        Message GetById(int id);

        Message AddNew(Message message);

        void DeleteMessage(int id);
    }
}
