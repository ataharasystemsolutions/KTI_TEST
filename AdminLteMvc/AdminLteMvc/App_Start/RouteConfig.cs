using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminLteMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "AdminLte", action = "Index", id = UrlParameter.Optional },
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces:  new[] {"AdminLteMvc.Controllers"}
            );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            //...
            Database.SetInitializer<AdminLteMvc.Models.ContextModel>(null);
        }
    }
}
