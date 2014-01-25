using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lawyer.Startup))]
namespace Lawyer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
