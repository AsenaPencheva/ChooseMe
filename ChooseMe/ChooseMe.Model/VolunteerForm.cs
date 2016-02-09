namespace ChooseMe.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class VolunteerForm: Form
    {
        public bool CanBeFosterHome { get; set; }

        public bool CanTakeCareOfBabyAnimal { get; set; }

        public bool CanTakeCareOfHandicappedAnimal { get; set; }

        public bool CanHelpWithAdministrationWork { get; set; }

        public bool CanHelpWithTransportingAnimal { get; set; }

        public bool CanHelpWithEvents { get; set; }

        public bool CanHelpWithOnlinePresence { get; set; }

        public string Other { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public Organization Organization{ get; set; }
    }
}
