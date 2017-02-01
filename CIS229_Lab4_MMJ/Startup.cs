using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS229_Lab4_MMJ.Startup))]
namespace CIS229_Lab4_MMJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
