namespace ChooseMe.Web.Models.Organization
{
    using Animal;
    using AutoMapper;
    using ChooseMe.Models;
    using Infrastructure.Mappings;
    using System.Collections.Generic;

    public class OrganizationDetailView: IMapFrom<Organization>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public bool IsLookingForVolunteers { get; set; }

        public IEnumerable<AnimalsListView> Animals { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationDetailView>()
                .ForMember(m => m.Animals, opt => opt.MapFrom(x => x.Animals));
         }
    }
}