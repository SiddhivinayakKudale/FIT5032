using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessConsultancyv4.Startup))]
namespace FitnessConsultancyv4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
