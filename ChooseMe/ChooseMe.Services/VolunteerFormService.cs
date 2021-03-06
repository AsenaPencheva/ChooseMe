﻿namespace ChooseMe.Services
{
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    using System;

    public class VolunteerFormService : IVolunteerFormService
    {
        private readonly IRepository<VolunteerForm> volunteerForms;

        public VolunteerFormService(IRepository<VolunteerForm> volunteerForms)
        {
            this.volunteerForms = volunteerForms;
        }

        public VolunteerForm AddNew(VolunteerForm form)
        {
            this.volunteerForms.Add(form);

            this.volunteerForms.SaveChanges();

            return form;
        }

        public void DeleteVolunteerForm(int id)
        {
            this.volunteerForms.Delete(id);

            this.volunteerForms.SaveChanges();
        }

        public IQueryable<VolunteerForm> GetAllByOrganizationId(string id)
        {
          return this.volunteerForms
                .All()
                .Where(f => f.OrganizationId == id)
                .OrderByDescending(vf => vf.CreatedOn); 
        }

        public IQueryable<VolunteerForm> GetAllByAdopterId(string id)
        {
            return this.volunteerForms
                  .All()
                 .Where(f => f.UserId == id)
                  .OrderByDescending(vf => vf.CreatedOn);
        }

        public IQueryable<VolunteerForm> GetById(int id)
        {
            return this.volunteerForms
                .All()
                .Where(f => f.Id == id);
        }
    }
}
