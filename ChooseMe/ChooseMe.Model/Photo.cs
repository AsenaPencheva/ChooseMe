namespace ChooseMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
