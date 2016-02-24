namespace ChooseMe.Web.Areas.Admin.Models
{
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;
    using System;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;
    public class AnimalsListView:IMapFrom<Animal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedOn { get; set; }

        public string Name { get; set; }

        public string OrganizationName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Animal, AnimalsListView>()
                .ForMember(m => m.OrganizationName, opts => opts.MapFrom(x => x.Organization.Name));
        }
    }
}