using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IColaboradorReadOnlyRepository : IReadOnlyRepository<Colaborador>
    {
        IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO();

        IEnumerable<dynamic> All_ID();
    }
}
