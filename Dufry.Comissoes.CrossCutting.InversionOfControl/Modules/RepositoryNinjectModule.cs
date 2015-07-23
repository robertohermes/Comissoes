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
           
        }
    }
}
