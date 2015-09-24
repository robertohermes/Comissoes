using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;

namespace Dufry.Comissoes.Domain.Interfaces.Service
{
    public interface IControleAcessoService : IService<ControleAcesso>
    {
        ControleAcesso GetFirstLogin();

        ControleAcesso FindByActiveLogin(string login);

        ControleAcesso Get_FilhosDiretos(int id);
    }
}
