namespace ChooseMe.Tests
{
    using ChooseMe.Models;
    using Common.Enums;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;

    class ObjectFactory
    {
        public static IQueryable<Animal> animals = new List<Animal>
        {
            new Animal
            {
                Id = 1,
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
            },

            new Animal
            {
                Id = 3,
                Type = AnimalType.Cat,
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2014, 01, 12),
                IsKidsFriendly = true,
                IsDogsFriendly = false,
                IsCatsFriendly = true,
                 FurColor  = FurColor.Mixed,
                 IsLonghaired = true,
                 IsCastraited  = true,
                 IsVaccinated = true,
                 IsChipped  = true,
                 OrganizationId = "n12sudoshjihyfiifosi"
            }

        }.AsQueryable();

        public static IQueryable<Organization> organizations = new List<Organization>
        {
            new Organization
            {
                Name = "IAdopt",
                CreatedOn = new DateTime(2015, 03, 12)
            },

            new Organization
            {
                Name = "IHelp",
                CreatedOn = new DateTime(2014, 03, 12)
            },

            new Organization
            {
                Name = "Adopters",
                CreatedOn = new DateTime(2015, 07, 12)
            },

        }.AsQueryable();

        public static IAnimalService GetAnimalService()
        {
            var animalService = new Mock<IAnimalService>();

            animalService.Setup(x => x.GetAll())
                .Returns(animals);

            animalService.Setup(x => x.GetLatestCats(
                It.Is<int>(v => v == 1)))
                .Returns(animals.Where(x => x.Id == 1));

            animalService.Setup(x => x.GetLatestCats(
              It.Is<int>(v => v == 1)))
             .Returns(animals.Where(x => x.Id == 2));

            return animalService.Object;
        }

        public static IOrganizationService GetOrganizationService()
        {
            var organizationService = new Mock<IOrganizationService>();

            organizationService.Setup(x => x.OrganizationWithMostAnimals(3))
                .Returns(organizations);


            return organizationService.Object;
        }
    }
}
