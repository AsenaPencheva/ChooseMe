namespace ChooseMe.Models
{
    using ChooseMe.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdoptionForm: Form
    {
        public string Address { get; set; }

        public bool IsOwningOtherAnimals { get; set; }

        public string AnimalsDescription { get; set; }

        public string ExpirienceWithAnimals { get; set; }

        public ResidenceType ResidenceType { get; set; }

        public bool IsKidsInHome { get; set; }

        public string KidsDescription { get; set; }

        public string AttitudeAboutCastration { get; set; }

        public bool IsHomecheckAndContactAllowed { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
