namespace ChooseMe.Web.Models.Forms
{
    using System;
    using AutoMapper;
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;

    public class VolunteerFormDetailViewModel : IMapFrom<VolunteerForm>, IHaveCustomMappings
    {
        public bool CanBeFosterHome { get; set; }

        public bool CanTakeCareOfBabyAnimal { get; set; }

        public bool CanTakeCareOfHandicappedAnimal { get; set; }

        public bool CanHelpWithAdministrationWork { get; set; }

        public bool CanHelpWithTransportingAnimal { get; set; }

        public bool CanHelpWithEvents { get; set; }

        public bool CanHelpWithOnlinePresence { get; set; }

        public string Other { get; set; }

        public string OrganizationName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<VolunteerForm, VolunteerFormDetailViewModel>()
                .ForMember(m => m.OrganizationName, opts => opts.MapFrom(x => x.Organization.Name));
        }
    }
}