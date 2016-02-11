namespace ChooseMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public Adopter User { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}