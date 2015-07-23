using Dufry.Comissoes.Data.Repository.EntityFramework.Common;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using System.Linq;

namespace Dufry.Comissoes.Data.Repository.EntityFramework
{
    public class ControleAcessoRepository : Repository<ControleAcesso>, IControleAcessoRepository
    {

        public ControleAcesso FindByActiveLogin(string login)
        {
            ControleAcesso usuario = Find(t => t.LOGIN == login && t.STATUS == "A").FirstOrDefault();

            return usuario;
        }
    }
}
