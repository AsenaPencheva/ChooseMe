namespace ChooseMe.Model
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        private ICollection<Town> towns;

        private ICollection<Like> likes;

        private ICollection<Comment> comments;

        private ICollection<AdoptionForm> adoptionForms;

        public Animal()
        {
            this.towns = new HashSet<Town>();
            this.towns = new HashSet<Like>();
            this.towns = new HashSet<Comment>();
            this.towns = new HashSet<AdoptionForm>();
        }

        [Key]
        public int Id { get; set; }

        public AnimalType Type { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Story { get; set; }

        public string Disease { get; set; }

        public bool IsKidsFriendly { get; set; }

        public bool IsDogsFriendly { get; set; }

        public bool IsCatsFriendly { get; set; }

        public FurColor FurColor { get; set; }

        public bool IsLonghaired { get; set; }

        public bool IsCastraited { get; set; }

        public bool IsVaccinated { get; set; }

        public bool IsChipped { get; set; }

        public string OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<Town> Towns
        {
            get { return this.towns; }
            set { this.towns = value; }
        }

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
    }
}
