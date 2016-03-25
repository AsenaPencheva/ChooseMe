namespace ChooseMe.Web.Models.Animal
{
    using AutoMapper;
    using ChooseMe.Models;
    using Common.Enums;
    using Infrastructure.Mappings;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class AnimalDetailView: IMapFrom<Animal>, IHaveCustomMappings
    {
        public string Id { get; set; }
        [Required]
        public AnimalType Type { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long!")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Age { get; set; }

        public string Story { get; set; }

        public string Disease { get; set; }

        [Required]
        public bool IsKidsFriendly { get; set; }

        [Required]
        public bool IsDogsFriendly { get; set; }

        [Required]
        public bool IsCatsFriendly { get; set; }

        [Required]
        public FurColor FurColor { get; set; }

        [Required]
        public bool IsLonghaired { get; set; }

        [Required]
        public bool IsCastraited { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }

        [Required]
        public bool IsChipped { get; set; }

        [Required]
        public string OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<AdoptionForm> AdoptionForms { get; set; }

        public IEnumerable<Photo> Photos { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Animal, AnimalDetailView>()
                .ForMember(m => m.AdoptionForms, opt => opt.MapFrom(x => x.AdoptionForms))
                .ForMember(m => m.Comments, opt => opt.MapFrom(x => x.Comments))
                .ForMember(m => m.Photos, opt => opt.MapFrom(x => x.Photos))
                .ForMember(a => a.Age, opts => opts.MapFrom(x => DateTime.UtcNow.Year - x.DateOfBirth.Year == 0 ?
                                                                                            (DateTime.UtcNow.Month - x.DateOfBirth.Month) + " months"
                                                                                            : DateTime.UtcNow.Year - x.DateOfBirth.Year + ""));
        }

    }
}