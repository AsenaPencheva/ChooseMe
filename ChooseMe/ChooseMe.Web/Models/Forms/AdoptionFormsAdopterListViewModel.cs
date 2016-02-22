namespace ChooseMe.Web.Models.Forms
{
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class AdoptionFormsAdopterListViewModel:IMapFrom<AdoptionForm>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AnimalName { get; set; }

        public int AnimalId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AdoptionForm, AdoptionFormsAdopterListViewModel>()
                    .ForMember(m => m.AnimalName, opt => opt.MapFrom(x => x.Animal.Name));
        }
    }
}