using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESAD_CS_R72_M_06_MVC_D010.Startup))]
namespace ESAD_CS_R72_M_06_MVC_D010
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
