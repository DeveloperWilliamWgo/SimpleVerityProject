﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleVerityProject.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movimento", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("BuscarCosif",
                            "Movimento/BuscarCosif/",
                            new { controller = "Movimento", action = "BuscarCosif" },
                            new[] { "SimpleVerityProject.Web.Controllers" });

            routes.MapRoute("SalvarMovimento",
                            "Movimento/SalvarMovimento/",
                            new { controller = "Movimento", action = "SalvarMovimento" },
                            new[] { "SimpleVerityProject.Web.Controllers" });
        }
    }
}
