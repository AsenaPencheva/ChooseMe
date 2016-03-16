namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment AddNew(Comment comment)
        {
            this.comments.Add(comment);

            this.comments.SaveChanges();

            return comment;
        }

        public void DeleteComment(int id)
        {
            this.comments.Delete(id);

            this.comments.SaveChanges();
        }

        public IQueryable<Comment> GetAllByAnimalId(int animalId)
        {
            return this.comments
                .All()
                .Where(c => c.AnimalId == animalId)
                .OrderByDescending(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetAllByUserId(string id)
        {
            return this.comments
                .All()
                .Where(c => c.UserId == id);
        }

        public Comment GetById(int id)
        {
            return this.comments
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
