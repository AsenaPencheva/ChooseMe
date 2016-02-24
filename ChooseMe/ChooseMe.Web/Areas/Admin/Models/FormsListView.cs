namespace ChooseMe.Web.Areas.Admin.Models
{
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;
    using System;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    public class FormsListView:IMapFrom<Form>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Form, FormsListView>()
                .ForMember(m => m.Author, opts => opts.MapFrom(x => x.User.UserName));
        }
    }
}