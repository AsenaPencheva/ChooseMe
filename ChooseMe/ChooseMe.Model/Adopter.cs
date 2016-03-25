namespace ChooseMe.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ChooseMe.Common.Constants;

    public class Adopter: User
    {
        private ICollection<Rating> likes;

        private ICollection<AdoptionForm> adoptionForms;

        private ICollection<Godparent> godparents;
        
        public Adopter()
        {
            this.likes = new HashSet<Rating>();
            this.adoptionForms = new HashSet<AdoptionForm>();
            this.godparents = new HashSet<Godparent>();
        }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ModelsConst.MaxLengthName, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ModelsConst.MinLengthName)]
        public string LastName { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.likes; }
            set { this.likes = value; }
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
