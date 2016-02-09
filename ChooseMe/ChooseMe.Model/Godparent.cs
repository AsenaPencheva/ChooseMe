namespace ChooseMe.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Godparent
    {
        [Key]
        public int Id;

        public GodparentType Type { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
