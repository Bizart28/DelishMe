using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DelishMe.Web.Startup))]
namespace DelishMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
