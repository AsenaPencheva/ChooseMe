namespace ChooseMe.Tests
{
    using ChooseMe.Models;
    using Common.Enums;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using Web.Models.Organization;
    class ObjectFactory
    {
        public static IQueryable<Animal> animals = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                Name = "Kara",
                AddedOn = new DateTime(2015, 01, 12),
                Type = AnimalType.Cat,
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2015, 03, 12),
                IsKidsFriendly = true,
                IsDogsFriendly = false,
                IsCatsFriendly = true,
                 FurColor  = FurColor.Black,
                 IsLonghaired = true,
                 IsCastraited  = false,
                 IsVaccinated = true,
                 IsChipped  = true,
                 OrganizationId = "n12sudosfiifosi"
            },

            new Animal
            {
                Id = 2,
                Name = "Sharo",
                AddedOn = new DateTime(2016, 01, 12),
                Type = AnimalType.Dog,
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2015, 07, 12),
                IsKidsFriendly = true,
                IsDogsFriendly = true,
                IsCatsFriendly = true,
                 FurColor  = FurColor.Calico,
                 IsLonghaired = false,
                 IsCastraited  = false,
                 IsVaccinated = true,
                 IsChipped  = true,
                 OrganizationId = "n12sudosfiifosi"
            }
        }.AsQueryable();

        public static IQueryable<Organization> organizations = new List<Organization>
        {
            new Organization
            {
                Name = "IAdopt",
                CreatedOn = new DateTime(2015, 03, 12),
                IsLookingForVolunteers = false,
                 Animals = { new Animal(), new Animal(), new Animal()}
            },

            new Organization
            {
                Name = "IHelp",
                CreatedOn = new DateTime(2014, 03, 12),
                IsLookingForVolunteers = true,
                Animals = { new Animal()}
            },

            new Organization
            {
                Name = "Adopters",
                CreatedOn = new DateTime(2014, 03, 12),
                IsLookingForVolunteers = true,
                Animals = { new Animal(), new Animal()}
            }

        }.AsQueryable();

        public static IQueryable<Adopter> adopters = new List<Adopter>
        {
            new Adopter
            {
                FirstName = "Alisa",
                LastName = "Alice",
                CreatedOn = new DateTime(2015, 03, 12),
            },

            new Adopter
            {
                FirstName = "Boyana",
                LastName = "Alice",
                CreatedOn = new DateTime(2014, 03, 12),
            },

            new Adopter
            {
                FirstName = "Martin",
                LastName = "Dow",
                CreatedOn = new DateTime(2014, 03, 12),
            },

        }.AsQueryable();

        public static IAnimalService GetAnimalService()
        {
            var animalService = new Mock<IAnimalService>();

            animalService.Setup(x => x.GetAll())
                .Returns(animals);

            return animalService.Object;
        }

        public static IOrganizationService GetOrganizationService()
        {
            var organizationService = new Mock<IOrganizationService>();

            organizationService.Setup(x => x.OrganizationWithMostAnimals(3))
                .Returns(organizations);

            organizationService.Setup(x => x.GetAll())
                .Returns(organizations);

            organizationService.Setup(x => x.GetById("1"))
                .Returns(organizations);

            return organizationService.Object;
        }

        public static IAdopterService GetAdopterService()
        {
            var adopterService = new Mock<IAdopterService>();

            adopterService.Setup(x => x.GetById("1"))
                .Returns(adopters);

            return adopterService.Object;
        }
    }
}
