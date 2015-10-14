using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IProdutoReadOnlyRepository : IReadOnlyRepository<Produto>
    {
        IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim);
    }
}
