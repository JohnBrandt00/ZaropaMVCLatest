using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZaropaMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                   "ShortAbout",
                   "about",
                   new { controller = "Home", action = "About" }
               );

            routes.MapRoute(
                  "Shortcontact",
                  "contact",
                  new { controller = "Home", action = "Contact" }
              );

            routes.MapRoute(
                  "Shop",
                  "Shop",
                  new { controller = "Products", action = "ProductPage" }
              );

            routes.MapRoute(
                 "ShopItem",
                 "Product/{id}",
                 new { controller = "Products", action = "ShowProduct",id=UrlParameter.Optional }
             );

            routes.MapRoute(
                 "AccountManage",
                 "ManageAccount",
                 new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
              "AccountRoute",
              "Login",
              new { controller = "Account", action = "Login", id = UrlParameter.Optional }
          );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           


        }
    }
}
