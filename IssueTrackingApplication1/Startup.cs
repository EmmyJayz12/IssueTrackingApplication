using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IssueTrackingApplication1.Startup))]
namespace IssueTrackingApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
