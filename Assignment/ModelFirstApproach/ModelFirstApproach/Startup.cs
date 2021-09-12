using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelFirstApproach.Startup))]
namespace ModelFirstApproach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
