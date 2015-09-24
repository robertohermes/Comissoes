using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;

namespace Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IControleAcessoReadOnlyRepository : IReadOnlyRepository<ControleAcesso>
    {
        ControleAcesso GetFirstLogin();

        ControleAcesso FindByActiveLogin(string login);

        ControleAcesso Get_FilhosDiretos(int id);
    }
}
