using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BurlOakMovers.Startup))]
namespace BurlOakMovers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
