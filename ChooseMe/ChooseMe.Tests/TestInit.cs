namespace ChooseMe.Tests
{
    using Common.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.App_Start;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.MVCProject);
        }
    }
}