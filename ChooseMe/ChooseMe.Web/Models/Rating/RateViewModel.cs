namespace ChooseMe.Web.Models.Rating
{
    using ChooseMe.Models;
    using Infrastructure.Mappings;
    using System.ComponentModel.DataAnnotations;

    public class RateViewModel:IMapFrom<Rating>
    {
        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        public string UserId { get; set; }

        public string OrganizationId { get; set; }
    }
}