namespace ChooseMe.Web.Areas.Organization.Models.Animal
{
    using Infrastructure.Mappings;
    using ChooseMe.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Collections.Generic;
    using Common.Enums;
    using System;
    public class MyAnimalsViewModel: IMapFrom<Animal>
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Cat or Dog")]
        public AnimalType Type { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long!")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        [Required]
        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Story { get; set; }

        public string Disease { get; set; }

        [Required]
        [DisplayName("Kids friendly")]
        public bool IsKidsFriendly { get; set; }

        [Required]
        [DisplayName("Dogs friendly")]
        public bool IsDogsFriendly { get; set; }

        [Required]
        [DisplayName("Cats friendly")]
        public bool IsCatsFriendly { get; set; }

        [Required]
        [DisplayName("Color")]
        public FurColor FurColor { get; set; }

        [Required]
        [DisplayName("Longhaired")]
        public bool IsLonghaired { get; set; }

        [Required]
        [DisplayName("Castraited")]
        public bool IsCastraited { get; set; }

        [Required]
        [DisplayName("Vaccinated")]
        public bool IsVaccinated { get; set; }

        [Required]
        [DisplayName("Chipped")]
        public bool IsChipped { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
    }
}