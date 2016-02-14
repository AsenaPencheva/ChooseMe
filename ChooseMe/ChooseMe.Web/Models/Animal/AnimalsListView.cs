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

        public Gender Gender { get; set; }

        public Organization Organization { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Animal, AnimalsListView>()
               .ForMember(a => a.Photo, opts => opts.MapFrom(x => x.Photos.FirstOrDefault().Address));
        }
    }
}