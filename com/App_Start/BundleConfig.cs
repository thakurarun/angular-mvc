using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace com
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var jQueryScriptBundle = new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/angular/jquery-1.10.2.js"
                         ,"~/Scripts/angular/modernizr-2.6.2.js"
                         );
            var angularScriptBundle = new ScriptBundle("~/bundles/angular").Include(
                         "~/Scripts/angular/angular.js"
                         , "~/Scripts/angular/bootstrap.js"
                         );

            var applicationScriptBundle = new ScriptBundle("~/bundles/application").Include(
                "~/Scripts/application/all.js"
                );

            bundles.Add(jQueryScriptBundle);
            bundles.Add(angularScriptBundle);
            bundles.Add(applicationScriptBundle);
            //BundleTable.EnableOptimizations = false;
        }
    }
}
