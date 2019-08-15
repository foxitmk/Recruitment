using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recruitment.Startup))]
namespace Recruitment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
