﻿namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using ChooseMe.Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;

    public class AdoptionFormService :IAdoptionFormService
    {
        private readonly IRepository<AdoptionForm> adoptionForms;

        public AdoptionFormService(IRepository<AdoptionForm> adoptionForms)
        {
            this.adoptionForms = adoptionForms;
        }

        public void AddNew(AdoptionForm form)
        {
            this.adoptionForms.
                Add(form);

            this.adoptionForms.SaveChanges();
        }

        public void DeleteAdoptionForm(int id)
        {
            this.adoptionForms.Delete(id);

            this.adoptionForms.SaveChanges();
        }

        public IQueryable<AdoptionForm> GetAllByAnimalId(int id)
        {
            return this.adoptionForms
                .All()
                .Where(af => af.AnimalId == id)
                .OrderByDescending(af => af.CreatedOn);
        }

        public IQueryable<AdoptionForm> GetAllByUserId(string id)
        {
            return this.adoptionForms
                .All()
                .Where(af => af.UserId == id)
                .OrderByDescending(af => af.CreatedOn);
        }

        public IQueryable<AdoptionForm> GetById(int id)
        {
            return this.adoptionForms
                .All()
                .Where(af => af.Id == id);
        }
    }
}
