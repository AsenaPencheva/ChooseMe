namespace ChooseMe.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;
    using System.ComponentModel;
    public class RegisterOrganizationViewModel: UserViewModel
    {
        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthDescription, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthDescription)]
        [Display(Name = "Short description")]
        public string Description { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        //public DateTime DateOfFoundation { get; set; }

        [Required]
        [DisplayName("Looking for volunteers")]
        public bool IsLookingForVolunteers { get; set; }
    }
}