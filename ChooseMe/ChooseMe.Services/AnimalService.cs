namespace ChooseMe.Services
{
    using System;
    using System.Linq;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    using Common.Enums;

    public class AnimalService: IAnimalService
    {
        private readonly IRepository<Animal> animals;

        public AnimalService(IRepository<Animal> animals)
        {
            this.animals = animals;
        }

        public Animal AddNew(Animal animal)
        {
            this.animals.Add(animal);

            this.animals.SaveChanges();

            return animal;
        }

        public void DeleteAnimal(int id)
        {
            this.animals.Delete(id);

            this.animals.SaveChanges();
        }

        public IQueryable<Animal> GetAll()
        {
            return this.animals
                .All()
                .OrderByDescending(a => a.AddedOn);
        }

        public IQueryable<Animal> GetAllByOrganizationId(string id)
        {
            return this.animals
                .All()
                .Where(a => a.OrganizationId == id);
        }

        public IQueryable<Animal> GetAllCats()
        {
            return this.animals
                .All()
                .Where(a => a.Type == AnimalType.Cat);
        }

        public IQueryable<Animal> GetAllDogs()
        {
            return this.animals
                 .All()
                 .Where(a => a.Type == AnimalType.Dog);
        }

        public IQueryable<Animal> GetById(int id)
        {
            return this.animals
                .All()
                .Where(a => a.Id == id);
        }

        public IQueryable<Animal> GetLatestCats(int number)
        {
            return this.animals
                .All()
                .Where(a => a.Type == AnimalType.Cat)
                .OrderByDescending(c => c.AddedOn)
                .Take(number);
        }

        public IQueryable<Animal> GetLatestDogs(int number)
        {
            return this.animals
                .All()
                .Where(a => a.Type == AnimalType.Dog)
                .OrderByDescending(c => c.AddedOn)
                .Take(number);
        }

        public IQueryable<Animal> UpdateAnimal(Animal updatedAnimal)
        {
            this.animals.Update(updatedAnimal);
            this.animals.SaveChanges();

            return this.animals
                .All()
                .Where(r => r.Id == updatedAnimal.Id);
        }
    }
}
