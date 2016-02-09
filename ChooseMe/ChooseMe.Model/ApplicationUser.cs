namespace ChooseMe.Models
{
    using System;
    using System.Collections.Generic;

    public class ApplicationUser: User
    {
        private ICollection<Like> likes;

        private ICollection<VolunteerForm> volunteerForms;

        private ICollection<AdoptionForm> adoptionForms;

        private ICollection<Godparent> godparents;
        
        public ApplicationUser()
        {
            this.likes = new HashSet<Like>();
            this.volunteerForms = new HashSet<VolunteerForm>();
            this.adoptionForms = new HashSet<AdoptionForm>();
            this.godparents = new HashSet<Godparent>();
        }

        public string FirstaName { get; set; }

        public string LastName { get; set; }

        public DateTime dateOfBirth { get; set; }

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
