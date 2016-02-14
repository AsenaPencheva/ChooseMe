namespace ChooseMe.Models
{
    using Common.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Animal
    {
        private ICollection<Like> likes;

        private ICollection<Comment> comments;

        private ICollection<AdoptionForm> adoptionForms;

        private ICollection<Photo> photos;

        public Animal()
        {
            this.AddedOn = DateTime.UtcNow;
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
            this.adoptionForms = new HashSet<AdoptionForm>();
            this.photos = new HashSet<Photo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public AnimalType Type { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long!")]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Story { get; set; }

        public string Disease { get; set; }

        [Required]
        public bool IsKidsFriendly { get; set; }

        [Required]
        public bool IsDogsFriendly { get; set; }

        [Required]
        public bool IsCatsFriendly { get; set; }

        [Required]
        public FurColor FurColor { get; set; }

        [Required]
        public bool IsLonghaired { get; set; }

        [Required]
        public bool IsCastraited { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }

        [Required]
        public bool IsChipped { get; set; }

        [Required]
        [ForeignKey("Organization")]
        public string OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<AdoptionForm> AdoptionForms
        {
            get { return this.adoptionForms; }
            set { this.adoptionForms = value; }
        }

        public virtual ICollection<Photo> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }
    }
}
