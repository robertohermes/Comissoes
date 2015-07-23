﻿using System.Web.Optimization;

namespace Dufry.Comissoes
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/jquery-validate").Include(
                "~/scripts/jquery-validate.js",
                "~/scripts/jquery-validate.unobtrusive.js"));

            bundles.Add(new StyleBundle("~/content/site").Include(
                "~/content/dufry.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

        }
    }
}