using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTemplate.MVC.Web.Startup))]
namespace ProjectTemplate.MVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
