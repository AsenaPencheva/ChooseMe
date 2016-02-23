namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IVolunteerFormService
    {
        IQueryable<VolunteerForm> GetAllByOrganizationId(string id);

        IQueryable<VolunteerForm> GetAllByAdopterId(string id);

        IQueryable<VolunteerForm> GetById(int id);

        VolunteerForm AddNew(VolunteerForm form);

        void DeleteVolunteerForm(int id);
    }
}
