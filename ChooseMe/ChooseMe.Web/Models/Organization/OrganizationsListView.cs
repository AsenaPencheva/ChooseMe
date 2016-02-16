namespace ChooseMe.Web.Models.Organization
{
    using ChooseMe.Models;
    using Infrastructure.Mappings;
    using AutoMapper;

    public class OrganizationsListView : IMapFrom<Organization>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int AnimalsNumber { get; set; }

        public string ImageURL { get; set; }

        public bool IsLookingForVolunteers { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationsListView>()
                .ForMember(m => m.AnimalsNumber, opt => opt.MapFrom(x => x.Animals.Count));
        }
    }
}