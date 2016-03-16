namespace ChooseMe.Web.Models.Comment
{
    using ChooseMe.Web.Infrastructure.Mappings;
    using ChooseMe.Models;
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public class CreateCommentViewModel:IMapFrom<Comment>, IHaveCustomMappings
    {
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public string Author { get; set; }

        public int AnimalId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CreateCommentViewModel>()
                .ForMember(m => m.Author, opts => opts.MapFrom(x => x.User.UserName));
        }
    }
}