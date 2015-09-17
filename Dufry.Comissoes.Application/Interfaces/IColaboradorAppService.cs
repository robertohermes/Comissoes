using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface IColaboradorAppService : IAppService<Colaborador>
    {
        IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO();
    }
}
