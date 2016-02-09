namespace ChooseMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}