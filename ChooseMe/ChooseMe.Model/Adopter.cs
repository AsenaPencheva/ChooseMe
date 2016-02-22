namespace ChooseMe.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;

    public class Adopter: User
    {
        private ICollection<Like> likes;

        private ICollection<VolunteerForm> volunteerForms;

        private ICollection<AdoptionForm> adoptionForms;

        private ICollection<Godparent> godparents;
        
        public Adopter()
        {
            this.likes = new HashSet<Like>();
            this.volunteerForms = new HashSet<VolunteerForm>();
            this.adoptionForms = new HashSet<AdoptionForm>();
            this.godparents = new HashSet<Godparent>();
        }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string LastName { get; set; }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<VolunteerForm> VolunteerForms
        {
            get { return this.volunteerForms; }
            set { this.volunteerForms = value; }
        }

        public virtual ICollection<AdoptionForm> AdoptionForms
        {
            get { return this.adoptionForms; }
            set { this.adoptionForms = value; }
        }

        public virtual ICollection<Godparent> Godparents
        {
            get { return this.godparents; }
            set { this.godparents = value; }
        }
    }
}
