﻿namespace ChooseMe.Web.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}