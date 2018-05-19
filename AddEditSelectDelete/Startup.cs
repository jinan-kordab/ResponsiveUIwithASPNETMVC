using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddEditSelectDelete.Startup))]
namespace AddEditSelectDelete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
