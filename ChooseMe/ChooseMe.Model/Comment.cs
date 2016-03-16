namespace ChooseMe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public Comment()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}