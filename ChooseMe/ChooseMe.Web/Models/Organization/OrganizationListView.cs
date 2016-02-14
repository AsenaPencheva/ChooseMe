namespace ChooseMe.Web.Models.Organization
{
    using Infrastructure.Mappings;
    using ChooseMe.Models;

    public class OrganizationListView: IMapFrom<Organization>
    {
        public string Name { get; set; }

        public string ImageURL { get; set; }
    }
}