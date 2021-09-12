using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginYoutubeIdentityExample.Startup))]
namespace LoginYoutubeIdentityExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
