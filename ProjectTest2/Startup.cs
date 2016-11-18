using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTest2.Startup))]
namespace ProjectTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
