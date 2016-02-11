namespace ChooseMe.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;
    using System;
    using System.ComponentModel;
    public class RegisterOrganizationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(Common.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Common.MinLengthName)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(Common.MaxLengthDescription, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Common.MinLengthDescription)]
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