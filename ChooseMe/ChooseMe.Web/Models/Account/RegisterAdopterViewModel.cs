namespace ChooseMe.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;
    using System;
    public class RegisterAdopterViewModel: UserViewModel
    {
        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

       // [Required]
       // [DataType(DataType.DateTime)]
        //public DateTime DateOfBirth { get; set; }
    }
}