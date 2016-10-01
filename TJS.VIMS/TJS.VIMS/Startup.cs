using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TJS.VIMS.Startup))]
namespace TJS.VIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
