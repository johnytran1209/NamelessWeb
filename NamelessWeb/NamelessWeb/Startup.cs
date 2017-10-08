using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NamelessWeb.Startup))]
namespace NamelessWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
