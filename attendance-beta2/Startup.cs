using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(attendance_beta2.Startup))]
namespace attendance_beta2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
