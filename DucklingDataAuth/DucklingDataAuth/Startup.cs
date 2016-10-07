using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DucklingDataAuth.Startup))]
namespace DucklingDataAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
