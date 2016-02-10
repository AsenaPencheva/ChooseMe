namespace ChooseMe.Models
{
    using ChooseMe.Common.Constants;
    using ChooseMe.Common.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdoptionForm: Form
    {
        [Required (ErrorMessage = ErrorMessages.ErrorRequired)]
        [MinLength(10, ErrorMessage = "Address must be at least 10 characters long!")]
        public string Address { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool IsOwningOtherAnimals { get; set; }

        public string AnimalsDescription { get; set; }

        public string ExpirienceWithAnimals { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public ResidenceType ResidenceType { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool IsKidsInHome { get; set; }

        public string KidsDescription { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        [MinLength(5, ErrorMessage = "Your answer must be at least 5 characters long!")]
        public string AttitudeAboutCastration { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool IsHomecheckAndContactAllowed { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
