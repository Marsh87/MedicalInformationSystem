using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalAppointmentMVC.Startup))]
namespace MedicalAppointmentMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
