using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(N_K_School.Startup))]
namespace N_K_School
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}