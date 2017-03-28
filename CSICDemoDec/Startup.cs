using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSICDemoDec.Startup))]
namespace CSICDemoDec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
            app.MapSignalR();
        }
    }
}
