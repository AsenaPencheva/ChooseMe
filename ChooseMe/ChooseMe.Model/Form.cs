﻿namespace ChooseMe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Form
    { 
        public Form()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Adopter User { get; set; }
    }
}
