using Dufry.Comissoes.Application;
using Dufry.Comissoes.Application.Interfaces;
using Ninject.Modules;

namespace Dufry.Comissoes.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IControleAcessoAppService>().To<ControleAcessoAppService>();
            Bind<IFilialAppService>().To<FilialAppService>();
            Bind<ILojaAppService>().To<LojaAppService>();
            Bind<IEmpresaAppService>().To<EmpresaAppService>();
            Bind<IColaboradorAppService>().To<ColaboradorAppService>();
        }
    }
}
