using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessConsultancy.Startup))]
namespace FitnessConsultancy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
