namespace ChooseMe.Web.Controllers
{
    using ChooseMe.Models;
    using Microsoft.AspNet.Identity;
    using Models.Animal;
    using Models.Comment;
    using PagedList;
    using Services.Contracts;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CommentsController : Controller
    {
        private ICommentService comments;
        private IAnimalService animals;
        private IUserService users;
        protected ISanitizer sanitizeService;

        public CommentsController(ICommentService comments, IAnimalService animals, IUserService users, ISanitizer sanitizeService)
        {
            this.comments = comments;
            this.animals = animals;
            this.users = users;
            this.sanitizeService = sanitizeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(CreateCommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Content = this.sanitizeService.Sanitize(model.Content);

                var newComment = AutoMapper.Mapper.Map<Comment>(model);

                newComment.Animal = this.animals.GetById(newComment.AnimalId).FirstOrDefault();

                newComment.UserId = User.Identity.GetUserId();

                newComment.User = this.users.GetById(User.Identity.GetUserId()).FirstOrDefault();

                this.comments.AddNew(newComment);

                var result = newComment.Animal.Comments;

                return this.PartialView("_Comments", result);
            }
            throw new HttpException(400, "Invalid Comment");
        }
    }
}