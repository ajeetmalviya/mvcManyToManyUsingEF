using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMDB.Web.Startup))]
namespace IMDB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
