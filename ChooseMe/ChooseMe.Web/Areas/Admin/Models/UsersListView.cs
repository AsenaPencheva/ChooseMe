namespace ChooseMe.Web.Areas.Admin.Models
{
    using ChooseMe.Models;
    using ChooseMe.Web.Infrastructure.Mappings;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Common.Constants;
    using System.Web.Security;
    public class UsersListView : IMapFrom<User>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}