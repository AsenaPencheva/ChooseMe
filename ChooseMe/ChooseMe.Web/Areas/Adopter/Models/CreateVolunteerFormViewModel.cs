namespace ChooseMe.Web.Areas.Adopter.Models
{
    using ChooseMe.Models;
    using Infrastructure.Mappings;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public class CreateVolunteerFormViewModel:IMapFrom<VolunteerForm>
    {
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "You must enter valid phone number!")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Can you be foster home?")]
        public bool CanBeFosterHome { get; set; }

        [DisplayName("Can you take care of baby animals?")]
        public bool CanTakeCareOfBabyAnimal { get; set; }

        [DisplayName("Can you take care of handicapped animals?")]
        public bool CanTakeCareOfHandicappedAnimal { get; set; }

        [DisplayName("Can you help with administrative work?")]
        public bool CanHelpWithAdministrationWork { get; set; }

        [DisplayName("Can you help with transporting of animals?")]
        public bool CanHelpWithTransportingAnimal { get; set; }

        [DisplayName("Can you help with organization of events?")]
        public bool CanHelpWithEvents { get; set; }

        [DisplayName("Can youhelp with online presence?")]
        public bool CanHelpWithOnlinePresence { get; set; }

        [AllowHtml]
        public string Other { get; set; }
    }
}