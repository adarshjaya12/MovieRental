﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieRentals
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "DetailCustomer",
                "Customer/Edit/{id}",
                new {  controller="Customers", action="Details"}
                );
            routes.MapRoute(
                "DetailMovies",
                "Movies/Details/{id}",
                new { controller="Movies" , action = "Details"},
                new { id =@"\d"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movies", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
