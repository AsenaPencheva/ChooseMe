namespace ChooseMe.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PagedList;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Services.Contracts;
    using Web.Areas.Adopter.Controllers;

    [TestClass]
    public class AdopterControllerTests
    {
        private AdoptersController controller;
        private IAdopterService adopters;

        [TestInitialize]
        public void Init()
        {
            this.adopters = ObjectFactory.GetAdopterService();
            this.controller = new AdoptersController(adopters);
        }

        [TestMethod]
        public void TestIfDetaillPageIsRetuned()
        {
            this.controller
              .WithCallTo(c => c.Details("1"))
              .ShouldRenderDefaultView();
        }
    }
}
