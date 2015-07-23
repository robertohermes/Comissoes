using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;

namespace Dufry.Comissoes.Domain.Interfaces.Repository
{
    public interface IControleAcessoRepository : IRepository<ControleAcesso>
    {

        ControleAcesso FindByActiveLogin(string login);

    }
}
