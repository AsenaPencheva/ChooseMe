﻿namespace ChooseMe.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<Message> messages;
        private ICollection<Comment> comments;
        private ICollection<VolunteerForm> volunteerForms;

        public User()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.messages = new HashSet<Message>();
            this.comments = new HashSet<Comment>();
            this.volunteerForms = new HashSet<VolunteerForm>();
        }

        public DateTime CreatedOn { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<VolunteerForm> VolunteerForms
        {
            get { return this.volunteerForms; }
            set { this.volunteerForms = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
