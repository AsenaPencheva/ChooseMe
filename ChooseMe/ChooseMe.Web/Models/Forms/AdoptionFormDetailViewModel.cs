namespace ChooseMe.Web.Models.Forms
{
    using System;
    using AutoMapper;
    using ChooseMe.Models;
    using Common.Enums;
    using Infrastructure.Mappings;
    public class AdoptionFormDetailViewModel:IMapFrom<AdoptionForm>, IHaveCustomMappings
    {
        public string Address { get; set; }

        public bool IsOwningOtherAnimals { get; set; }

        public string AnimalsDescription { get; set; }

        public string ExpirienceWithAnimals { get; set; }

        public ResidenceType ResidenceType { get; set; }

        public bool IsKidsInHome { get; set; }

        public string KidsDescription { get; set; }

        public string AttitudeAboutCastration { get; set; }

        public bool IsHomecheckAndContactAllowed { get; set; }

        public string AnimalName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AdoptionForm, AdoptionFormDetailViewModel>()
                .ForMember(m => m.AnimalName, opts => opts.MapFrom(x => x.Animal.Name));
        }
    }
}