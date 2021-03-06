﻿namespace ChooseMe.Web.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}