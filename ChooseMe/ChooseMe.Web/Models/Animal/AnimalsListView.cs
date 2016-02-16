namespace ChooseMe.Web.Models.Animal
{
    using Common.Enums;
    using Infrastructure.Mappings;
    using System;
    using AutoMapper;
    using ChooseMe.Models;
    using System.Linq;

    public class AnimalsListView: IMapFrom<Animal>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public DateTime AddedOn { get; set; }

        public AnimalType Type { get; set; }

        public string Age { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsLonghaired { get; set; }

        public FurColor FurColor { get; set; }

        public Organization Organization { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Animal, AnimalsListView>()
               .ForMember(a => a.Photo, opts => opts.MapFrom(x => x.Photos.FirstOrDefault().Address))
               .ForMember(a => a.Age, opts => opts.MapFrom(x => DateTime.UtcNow.Year - x.DateOfBirth.Year == 0 ?
                                                                                            (DateTime.UtcNow.Month - x.DateOfBirth.Month)  + " months"
                                                                                            : DateTime.UtcNow.Year - x.DateOfBirth.Year + ""));
        }
    }
}