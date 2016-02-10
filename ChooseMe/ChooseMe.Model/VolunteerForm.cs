namespace ChooseMe.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class VolunteerForm: Form
    {
        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanBeFosterHome { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanTakeCareOfBabyAnimal { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanTakeCareOfHandicappedAnimal { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanHelpWithAdministrationWork { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanHelpWithTransportingAnimal { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanHelpWithEvents { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorRequired)]
        public bool CanHelpWithOnlinePresence { get; set; }

        public string Other { get; set; }

        [ForeignKey("Organization")]
        public string OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
