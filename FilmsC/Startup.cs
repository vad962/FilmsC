using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmsC.Startup))]
namespace FilmsC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
