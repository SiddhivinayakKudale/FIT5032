using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpEg1.Startup))]
namespace CSharpEg1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
