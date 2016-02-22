namespace ChooseMe.Web.Models.Forms
{
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;
    using System;
    using System.ComponentModel;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    public class FormsListView : IMapFrom<AdoptionForm>, IHaveCustomMappings
    {
        public string ImageURL { get; set; }

        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Full name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Form, FormsListView>()
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(m => m.FullName, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));
        }
    }
}