using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface IControleAcessoAppService : IAppService<ControleAcesso>
    {
        ControleAcesso GetFirstLogin();

        ControleAcesso FindByActiveLogin(string login);

        string ObtainCurrentLoginFromAd();
    }
}
