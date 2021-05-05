using System.Web;
using System.Web.Optimization;

namespace ZaropaMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/MDBootstrap/js/popper.min.js",
                "~/Scripts/jquery-1.10.2.js",
                      "~/Content/MDBootstrap/js/bootstrap.js",
                      "~/Content/MDBootstrap/js/bootstrap.min.js",
                      "~/Content/MDBootstrap/js/jquery-3.2.1.min.js",
                      "~/Content/MDBootstrap/js/mdb.js",
                      "~/Content/smooth-scroll.js",
                      "~/Content/MDBootstrap/js/mdb.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/MDBootstrap/css/bootstrap.css",
                      "~/Content/MDBootstrap/css/bootstrap.min.css",
                      "~/Content/MDBootstrap/css/mdb.css",
                      "~/Content/MDBootstrap/css/mdb.min.css",
                      "~/Content/MDBootstrap/css/style.css"
                      //"https://maxcdn.bootstrapcdn.com/font-awesome/4.6.0/css/font-awesome.min.css"
                      ));
        }
    }
}
