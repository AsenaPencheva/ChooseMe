namespace ChooseMe.Models
{
    using Common.Enums;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        private ICollection<Animal> canTravelToAnimals;

        private ICollection<Organization> organizations;

        private ICollection<ApplicationUser> users;

        public Town()
        {
            this.canTravelToAnimals = new HashSet<Animal>();
            this.organizations = new HashSet<Organization>();
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public CountriesEnum Country { get; set; }

        public virtual ICollection<Animal> CanTravelToAnimals
        {
            get { return this.canTravelToAnimals; }
            set { this.canTravelToAnimals = value; }
        }

        public virtual ICollection<Organization> Organizations
        {
            get { return this.organizations; }
            set { this.organizations = value; }
        }

        public virtual ICollection<ApplicationUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}