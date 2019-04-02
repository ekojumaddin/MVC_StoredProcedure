using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_StoredProcedure.Startup))]
namespace MVC_StoredProcedure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
