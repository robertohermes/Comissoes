using System.Web.Optimization;

namespace Dufry.Comissoes
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.replace-text.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                //"~/scripts/jquery.unobtrusive-ajax.js",
                "~/scripts/jquery.validate-vsdoc.js",
                "~/scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js", 
                "~/scripts/globalize.js", 
                "~/scripts/jquery.validate.globalize.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.js",
                      "~/scripts/respond.js"));

            bundles.Add(new StyleBundle("~/content/site").Include(
                "~/content/dufry.css"));

            bundles.Add(new StyleBundle("~/content/jqueryui").Include(
                "~/content/themes/base/all.css"));


            bundles.Add(new StyleBundle("~/content/themes/base/css").Include(
                "~/content/themes/base/jquery.ui.core.css", 
                "~/content/themes/base/jquery.ui.resizable.css", 
                "~/content/themes/base/jquery.ui.selectable.css", 
                "~/content/themes/base/jquery.ui.accordion.css", 
                "~/content/themes/base/jquery.ui.autocomplete.css", 
                "~/content/themes/base/jquery.ui.button.css", 
                "~/content/themes/base/jquery.ui.dialog.css", 
                "~/content/themes/base/jquery.ui.slider.css", 
                "~/content/themes/base/jquery.ui.tabs.css", 
                "~/content/themes/base/jquery.ui.datepicker.css", 
                "~/content/themes/base/jquery.ui.progressbar.css", 
                "~/content/themes/base/jquery.ui.theme.css"));



#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

        }
    }
}