using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using Dufry.Comissoes.Domain.Services;
using Dufry.Comissoes.Domain.Services.Common;
using Ninject.Modules;

namespace Dufry.Comissoes.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IService<>)).To(typeof (Service<>));

            Bind<IControleAcessoService>().To<ControleAcessoService>();
            Bind<IFilialService>().To<FilialService>();
        }
    }
}
