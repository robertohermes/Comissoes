using Dufry.Comissoes.Data.Repository.Dapper;
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

            Bind<IFilialRepository>().To<FilialRepository>();
            Bind<IFilialReadOnlyRepository>().To<FilialDapperRepository>();
            Bind<IReadOnlyRepository<Filial>>().To<FilialDapperRepository>();

            Bind<ILojaRepository>().To<LojaRepository>();
            //Bind<ILojaReadOnlyRepository>().To<LojaDapperRepository>();
            //Bind<IReadOnlyRepository<Loja>>().To<LojaDapperRepository>();

            Bind<IEmpresaRepository>().To<EmpresaRepository>();
            //Bind<IEmpresaReadOnlyRepository>().To<EmpresaDapperRepository>();
            //Bind<IReadOnlyRepository<Empresa>>().To<EmpresaDapperRepository>();

            Bind<IColaboradorRepository>().To<ColaboradorRepository>();
            //Bind<IColaboradorReadOnlyRepository>().To<ColaboradorDapperRepository>();
            //Bind<IReadOnlyRepository<Colaborador>>().To<ColaboradorDapperRepository>();
           
        }
    }
}
