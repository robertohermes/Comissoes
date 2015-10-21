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
            Bind<IAusenciaRemuneradaService>().To<AusenciaRemuneradaService>();
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<ISelfServiceService>().To<SelfServiceService>();
            Bind<IPlanoService>().To<PlanoService>();
            Bind<IDolarMedioService>().To<DolarMedioService>();
            Bind<IPlanoCategoriaService>().To<PlanoCategoriaService>();
            Bind<IDSRService>().To<DSRService>();
            Bind<ICategoriaPercentualService>().To<CategoriaPercentualService>();
            Bind<IPlanoLojaService>().To<PlanoLojaService>();
            Bind<IConfiguracaoService>().To<ConfiguracaoService>();

            Bind<IFilialService>().To<FilialService>();
            Bind<ILojaService>().To<LojaService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IColaboradorService>().To<ColaboradorService>();
            Bind<ICargoService>().To<CargoService>();
            Bind<ITipoNegocioService>().To<TipoNegocioService>();
            Bind<IProdutoService>().To<ProdutoService>();
            Bind<ITipoBusinessService>().To<TipoBusinessService>();
        }
    }
}
