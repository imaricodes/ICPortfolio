using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(icportfolio.Startup))]
namespace icportfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
