namespace ChooseMe.Models
{
    using Common.Enums;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        private ICollection<Organization> organizations;

        private ICollection<Adopter> users;

        public Town()
        {
            this.organizations = new HashSet<Organization>();
            this.users = new HashSet<Adopter>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public CountriesEnum Country { get; set; }

        public virtual ICollection<Organization> Organizations
        {
            get { return this.organizations; }
            set { this.organizations = value; }
        }

        public virtual ICollection<Adopter> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}