using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using Dufry.Comissoes.AutoMapper;
using Dufry.Comissoes.Data.Context;
using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_EndRequest()
        {
            var comissoesContextManager = ServiceLocator.Current.GetInstance<IContextManager<ComissoesContext>>() as ContextManager<ComissoesContext>;
            if (comissoesContextManager != null)
            {
                comissoesContextManager.GetContext().Dispose();
            }

            var biVendasContextManager = ServiceLocator.Current.GetInstance<IContextManager<BIVendasContext>>() as ContextManager<BIVendasContext>;
            if (biVendasContextManager != null)
            {
                biVendasContextManager.GetContext().Dispose();
            }
        }
    }
}