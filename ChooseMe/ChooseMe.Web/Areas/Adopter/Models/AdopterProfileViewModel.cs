namespace ChooseMe.Web.Areas.Adopter.Models
{
    using Infrastructure.Mappings;
    using ChooseMe.Models;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using System;
    public class AdopterProfileViewModel:IMapFrom<Adopter>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string LastName { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }
    }
}