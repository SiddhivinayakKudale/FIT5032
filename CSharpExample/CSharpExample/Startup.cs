using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpExample.Startup))]
namespace CSharpExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
