using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAdemo.Startup))]
namespace GAdemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
