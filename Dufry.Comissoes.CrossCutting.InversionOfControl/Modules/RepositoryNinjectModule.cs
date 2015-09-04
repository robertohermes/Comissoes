﻿using Dufry.Comissoes.Data.Repository.Dapper;
using Dufry.Comissoes.Data.Repository.EntityFramework;
using Dufry.Comissoes.Data.Repository.EntityFramework.Common;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Ninject.Modules;

namespace Dufry.Comissoes.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepository<>)).To(typeof (Repository<>));

            Bind<IControleAcessoRepository>().To<ControleAcessoRepository>();
            Bind<IControleAcessoReadOnlyRepository>().To<ControleAcessoDapperRepository>();
            Bind<IReadOnlyRepository<ControleAcesso>>().To<ControleAcessoDapperRepository>();




            Bind<IAusenciaRemuneradaRepository>().To<AusenciaRemuneradaRepository>();
            Bind<IAusenciaRemuneradaReadOnlyRepository>().To<AusenciaRemuneradaDapperRepository>();
            Bind<IReadOnlyRepository<AusenciaRemunerada>>().To<AusenciaRemuneradaDapperRepository>();

            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind<ICategoriaReadOnlyRepository>().To<CategoriaDapperRepository>();
            Bind<IReadOnlyRepository<Categoria>>().To<CategoriaDapperRepository>();

            Bind<ISelfServiceRepository>().To<SelfServiceRepository>();
            Bind<ISelfServiceReadOnlyRepository>().To<SelfServiceDapperRepository>();
            Bind<IReadOnlyRepository<SelfService>>().To<SelfServiceDapperRepository>();

            Bind<IPlanoRepository>().To<PlanoRepository>();
            Bind<IPlanoReadOnlyRepository>().To<PlanoDapperRepository>();
            Bind<IReadOnlyRepository<Plano>>().To<PlanoDapperRepository>();

            Bind<IDolarMedioRepository>().To<DolarMedioRepository>();
            Bind<IDolarMedioReadOnlyRepository>().To<DolarMedioDapperRepository>();
            Bind<IReadOnlyRepository<DolarMedio>>().To<DolarMedioDapperRepository>();

            Bind<IPlanoCategoriaRepository>().To<PlanoCategoriaRepository>();
            Bind<IPlanoCategoriaReadOnlyRepository>().To<PlanoCategoriaDapperRepository>();
            Bind<IReadOnlyRepository<PlanoCategoria>>().To<PlanoCategoriaDapperRepository>();

            Bind<IDSRRepository>().To<DSRRepository>();
            Bind<IDSRReadOnlyRepository>().To<DSRDapperRepository>();
            Bind<IReadOnlyRepository<DSR>>().To<DSRDapperRepository>();

            Bind<ICategoriaPercentualRepository>().To<CategoriaPercentualRepository>();
            Bind<ICategoriaPercentualReadOnlyRepository>().To<CategoriaPercentualDapperRepository>();
            Bind<IReadOnlyRepository<CategoriaPercentual>>().To<CategoriaPercentualDapperRepository>();

            Bind<IPlanoLojaRepository>().To<PlanoLojaRepository>();
            Bind<IPlanoLojaReadOnlyRepository>().To<PlanoLojaDapperRepository>();
            Bind<IReadOnlyRepository<PlanoLoja>>().To<PlanoLojaDapperRepository>();






            Bind<IFilialRepository>().To<FilialRepository>();
            Bind<IFilialReadOnlyRepository>().To<FilialDapperRepository>();
            Bind<IReadOnlyRepository<Filial>>().To<FilialDapperRepository>();

            Bind<ILojaRepository>().To<LojaRepository>();
            Bind<ILojaReadOnlyRepository>().To<LojaDapperRepository>();
            Bind<IReadOnlyRepository<Loja>>().To<LojaDapperRepository>();

            Bind<IEmpresaRepository>().To<EmpresaRepository>();
            Bind<IEmpresaReadOnlyRepository>().To<EmpresaDapperRepository>();
            Bind<IReadOnlyRepository<Empresa>>().To<EmpresaDapperRepository>();

            Bind<IColaboradorRepository>().To<ColaboradorRepository>();
            Bind<IColaboradorReadOnlyRepository>().To<ColaboradorDapperRepository>();
            Bind<IReadOnlyRepository<Colaborador>>().To<ColaboradorDapperRepository>();

            Bind<ICargoRepository>().To<CargoRepository>();
            Bind<ICargoReadOnlyRepository>().To<CargoDapperRepository>();
            Bind<IReadOnlyRepository<Cargo>>().To<CargoDapperRepository>();
           
        }
    }
}
