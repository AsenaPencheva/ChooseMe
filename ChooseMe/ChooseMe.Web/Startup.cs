using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChooseMe.Web.Startup))]
namespace ChooseMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
