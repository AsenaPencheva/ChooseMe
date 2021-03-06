﻿namespace ChooseMe.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IAdopterService
    {
        IQueryable<Adopter> GetAll();

        IQueryable<Adopter> GetById(string id);

        IQueryable<Adopter> UpdateAdopter(Adopter updatedAdopter, Adopter user);

        void DeleteAdopter(string id);
    }
}