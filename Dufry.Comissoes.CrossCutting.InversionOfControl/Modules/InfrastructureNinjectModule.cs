using Dufry.Comissoes.Data.Context;
using Dufry.Comissoes.Data.Context.Interfaces;
using Ninject.Modules;

namespace Dufry.Comissoes.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<ComissoesContext>();
            Bind(typeof (IContextManager<>)).To(typeof (ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));
        }
    }
}
