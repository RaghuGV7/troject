using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Trogsoft.Project.Server.Startup))]

namespace Trogsoft.Project.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            HttpConfiguration htc = new HttpConfiguration();
            htc.Routes.MapHttpRoute("default", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(htc);

        }
    }
}
