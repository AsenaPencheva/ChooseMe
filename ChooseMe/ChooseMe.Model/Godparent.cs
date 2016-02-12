namespace ChooseMe.Models
{
    using Common.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Godparent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public GodparentType Type { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Adopter User { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
