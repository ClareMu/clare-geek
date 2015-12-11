using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Single_SignOn_Test.Startup))]
namespace Single_SignOn_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
