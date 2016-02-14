namespace ChooseMe.Services
{
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    public class MessageService: IMessageService
    {
        private readonly IRepository<Message> messages;

        public MessageService(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        public Message AddNew(Message message)
        {
            this.messages.Add(message);

            this.messages.SaveChanges();

            return message;
        }

        public void DeleteMessage(int id)
        {
            this.messages.Delete(id);

            this.messages.SaveChanges();
        }

        public IQueryable<Message> GetAllByUserId(string id)
        {
            return this.messages
                .All()
                .Where(m => m.UserId == id);
        }

        public Message GetById(int id)
        {
            return this.messages
                .All()
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
