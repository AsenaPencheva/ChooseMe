namespace ChooseMe.Services.Contracts
{
    using ChooseMe.Models;
    using System.Linq;

    public interface ICommentService
    {
        IQueryable<Comment> GetAllByUserId(string id);

        IQueryable<Comment> GetAllByAnimalId(int animalId);

        Comment GetById(int id);

        Comment AddNew(Comment comment);

        void DeleteComment(int id);
    }
}