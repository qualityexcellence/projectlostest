using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingProject1.Startup))]
namespace TestingProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
