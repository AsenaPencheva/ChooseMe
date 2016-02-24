namespace ChooseMe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Services.Contracts;
    using Services;
    using System.Collections.Generic;
    using Web.Areas.Admin.Models;
    using Web.Models.Organization;
    [TestClass]
    public class Home
    {
        private HomeController controller;
        private IAnimalService animals;
        private IOrganizationService organizations;
        private ICacheService cacheService;

        [TestInitialize]
        public void Init()
        {
            
            this.cacheService = new HttpCacheService();
            this.animals = ObjectFactory.GetAnimalService();
            this.organizations = ObjectFactory.GetOrganizationService();
            this.controller = new HomeController(animals, organizations, cacheService);
        }

        [TestMethod]
        public void TestIfIndexPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfLastCatsPartialIsReturned()
        {
            this.controller.WithCallTo(c => c.GetLastCats())
                .ShouldRenderPartialView("_LatestAnimals")
                .WithModel<List<AnimalsListView>>();
        }

      /*  [TestMethod]
        public void TestIfLastDogsPartialIsReturned()
        {
            this.controller.WithCallTo(c => c.GetLastDogs())
                .ShouldRenderPartialView("_LatestAnimals")
                .WithModel<List<AnimalsListView>>();
        }

        [TestMethod]
        public void TestIfOrgsMostAnimalslIsReturned()
        {
            this.controller.WithCallTo(c => c.GetOrganizationWithMostAnimals())
                .ShouldRenderPartialView("_OrgsMostAnimals")
                .WithModel<IEnumerable<OrganizationsListView>>();
        }*/
    }
}
