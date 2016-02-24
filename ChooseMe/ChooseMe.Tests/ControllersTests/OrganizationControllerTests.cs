namespace ChooseMe.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PagedList;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Services.Contracts;
    using Web.Models.Organization;
    [TestClass]
    public class OrganizationsControllerTests
    {
        private OrganizationsController controller;
        private IOrganizationService organizations;

        [TestInitialize]
        public void Init()
        {
            this.organizations = ObjectFactory.GetOrganizationService();
            this.controller = new OrganizationsController(organizations);
        }

        [TestMethod]
        public void TestIfAllPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.All(null, null, null, null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortsByNumberOfAnimalsIfNoOtherSortingParameter()
        {
            this.controller
                .WithCallTo(c => c.All(" ", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IHelp");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortsByNameAscending()
        {
            this.controller
                .WithCallTo(c => c.All("Name", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "Adopters");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortsByNameDescending()
        {
            this.controller
                .WithCallTo(c => c.All("name_desc", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IHelp");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSearchIsReturningCorrectValue()
        {
            this.controller
                .WithCallTo(c => c.All(" ", null, "IHelp", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IHelp");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortByIsLookingForVolunteersAscendingReturningCorrectValue()
        {
            this.controller
                .WithCallTo(c => c.All("LFVolunteers", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IAdopt");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortByIsLookingForVolunteersDescendingReturningCorrectValue()
        {
            this.controller
                .WithCallTo(c => c.All("lfvolunteers_desc", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IHelp");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortByNumberOfAnimalsAscendingReturningCorrectValue()
        {
            this.controller
                .WithCallTo(c => c.All("nanimals", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IHelp");
        }

        [TestMethod]
        public void TestIfOrganizationsAllSortByNumberOfAnimalsDescendingReturningCorrectValue()
        {
            this.controller
                .WithCallTo(c => c.All("NAnimals", null, null, null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<OrganizationsListView>>(m => m[0].Name == "IAdopt");
        }

        [TestMethod]
        public void TestIfDetailPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.Details("1"))
                .ShouldRenderDefaultView();
        }
    }
 }
