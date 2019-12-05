using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test_web.Startup))]
namespace test_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
