﻿using System.Web;
using System.Web.Optimization;

namespace SctJSKClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/customs").Include(
                        "~/Scripts/AdministrationNavScript.js", "~/Scripts/SearchScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //jQuery fullcalendar plugin css
            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                                      "~/Content/fullcalendar.css"));

            //jQuery fullcalendar plugin js
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                                      "~/Scripts/moment.js",  //Include the moment.js
                                      "~/Scripts/fullcalendar.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            
        }
    }
}
