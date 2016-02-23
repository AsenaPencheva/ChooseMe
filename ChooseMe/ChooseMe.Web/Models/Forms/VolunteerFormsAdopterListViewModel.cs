namespace ChooseMe.Web.Models.Forms
{
    using AutoMapper;
    using ChooseMe.Models;
    using Infrastructure.Mappings;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class VolunteerFormsAdopterListViewModel:IMapFrom<VolunteerForm>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public string OrganizationId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<VolunteerForm, VolunteerFormsAdopterListViewModel>()
                    .ForMember(m => m.OrganizationName, opt => opt.MapFrom(x => x.Organization.Name));
        }
    }
}