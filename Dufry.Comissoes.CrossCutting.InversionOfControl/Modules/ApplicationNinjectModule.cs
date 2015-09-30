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

            Bind<IAusenciaRemuneradaAppService>().To<AusenciaRemuneradaAppService>();
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
            Bind<ISelfServiceAppService>().To<SelfServiceAppService>();
            Bind<IPlanoAppService>().To<PlanoAppService>();
            Bind<IDolarMedioAppService>().To<DolarMedioAppService>();
            Bind<IPlanoCategoriaAppService>().To<PlanoCategoriaAppService>();
            Bind<IDSRAppService>().To<DSRAppService>();
            Bind<ICategoriaPercentualAppService>().To<CategoriaPercentualAppService>();
            Bind<IPlanoLojaAppService>().To<PlanoLojaAppService>();
            Bind<IConfiguracaoAppService>().To<ConfiguracaoAppService>();

            Bind<IFilialAppService>().To<FilialAppService>();
            Bind<ILojaAppService>().To<LojaAppService>();
            Bind<IEmpresaAppService>().To<EmpresaAppService>();
            Bind<IColaboradorAppService>().To<ColaboradorAppService>();
            Bind<ICargoAppService>().To<CargoAppService>();
            Bind<ITipoNegocioAppService>().To<TipoNegocioAppService>();
        }
    }
}
