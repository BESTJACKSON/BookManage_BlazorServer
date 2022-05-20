using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookManage.Startup))]
namespace BookManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
