namespace ChooseMe.Web.Models.Adopter
{
    using Infrastructure.Mappings;
    using ChooseMe.Models;

    public class AdopterDetailView: IMapFrom<Adopter>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageURL { get; set; }

        public string Email { get; set; }
    }
}