namespace ChooseMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Adopter User { get; set; }

        [ForeignKey("Organization")]
        public string OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
