using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IColaboradorReadOnlyRepository : IReadOnlyRepository<Colaborador>
    {
        IEnumerable<Colaborador> All_ID_COMPOSTO();
    }
}
