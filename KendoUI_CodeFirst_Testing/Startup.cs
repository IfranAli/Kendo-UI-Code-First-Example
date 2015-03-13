using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoUI_CodeFirst_Testing.Startup))]
namespace KendoUI_CodeFirst_Testing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
