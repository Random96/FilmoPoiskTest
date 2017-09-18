using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmoPoiskTest.Startup))]
namespace FilmoPoiskTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
