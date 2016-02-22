namespace ChooseMe.Web.Areas.Organization.Models.Organization
{
    using ChooseMe.Web.Infrastructure.Mappings;
    using ChooseMe.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel;
    public class OrganizationProfileViewModel:IMapFrom<Organization>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Organization name must be at leasr 5 characters long")]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Are you looking for volunteer?")]
        public bool IsLookingForVolunteers { get; set; }
    }
}