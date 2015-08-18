using System.Collections.Generic;
using System.Web.Optimization;

namespace Dufry.Comissoes
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/scripts/jquery-ui-{version}.js"));

            var bundle = new ScriptBundle("~/bundles/jqueryval") { Orderer = new AsIsBundleOrderer() };

            bundle
                .Include("~/scripts/jquery.unobtrusive*")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/moment.js")
                .Include("~/scripts/moment-with-locales.js")
                .Include("~/scripts/dufry.config.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js");
            bundles.Add(bundle);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.js",
                      "~/scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                    "~/scripts/jquery.mask.js"));
            //------------------------------------------------------------------------------------------------------------

            bundles.Add(new StyleBundle("~/content/site").Include(
                "~/content/dufry.css"));

            bundles.Add(new StyleBundle("~/content/jqueryui").Include(
                "~/content/themes/base/all.css"));


#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}