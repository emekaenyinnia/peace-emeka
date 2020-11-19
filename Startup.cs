using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppFiles.Startup))]
namespace AppFiles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
