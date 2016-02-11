namespace ChooseMe.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;
    using System;
    public class RegisterAdopterViewModel
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
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Common.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Common.MinLengthName)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}