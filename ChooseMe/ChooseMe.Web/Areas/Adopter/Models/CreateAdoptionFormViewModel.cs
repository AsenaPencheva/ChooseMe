namespace ChooseMe.Web.Areas.Adopter.Models
{
    using ChooseMe.Models;
    using Common.Constants;
    using Common.Enums;
    using Infrastructure.Mappings;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateAdoptionFormViewModel:IMapFrom<AdoptionForm>
    {
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage="You must enter valid phone number!")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        [MinLength(10, ErrorMessage = "Address must be at least 10 characters long!")]
        public string Address { get; set; }

        [DisplayName("Do you own other animals?")]
        public bool IsOwningOtherAnimals { get; set; }

        [DisplayName("If you have other animals, enter the age and type of them")]
        public string AnimalsDescription { get; set; }

        [DisplayName("Do you have any expirience with animals?")]
        public string ExpirienceWithAnimals { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        [DisplayName("Are you living in apartment or house?")]
        public ResidenceType ResidenceType { get; set; }

        [DisplayName("Do you have kids, who lives with you?")]
        public bool IsKidsInHome { get; set; }

        [DisplayName("If there is kids in the house, please enter their age")]
        public string KidsDescription { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        [MinLength(5, ErrorMessage = "Your answer must be at least 5 characters long!")]
        [DisplayName("What do you think about castration as form of control of the number of the stray animals?")]
        public string AttitudeAboutCastration { get; set; }

        [DisplayName("Do you agree to give information and photos of the animal and your home to be checked before adoption?")]
        public bool IsHomecheckAndContactAllowed { get; set; }
    }
}