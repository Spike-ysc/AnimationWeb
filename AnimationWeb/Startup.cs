using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimationWeb.Startup))]
namespace AnimationWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
