using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoHw.Startup))]
namespace ToDoHw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
