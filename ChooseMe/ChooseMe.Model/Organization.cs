namespace ChooseMe.Models
{
    using System;
    using System.Collections.Generic;

    public class Organization: User
    {
        private ICollection<Animal> animals;

        private ICollection<VolunteerForm> volunteerForms;

        public Organization()
        {
            this.animals = new HashSet<Animal>();
            this.volunteerForms = new HashSet<VolunteerForm>();
        }

        public string Name { get; set; }

        public DateTime ActiveSince { get; set; }

        public string Description { get; set; }

        public bool IsLookingForVolunteers { get; set; }

        public ICollection<Animal> Animals
        {
            get { return this.animals; }
            set { this.animals = value; }
        }

        public ICollection<VolunteerForm> VolunteerForms
        {
            get { return this.volunteerForms; }
            set { this.volunteerForms = value; }
        }
    }
}