using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface IProdutoAppService : IAppService<Produto>
    {
        IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim);

        IEnumerable<FolhaPagamento> InterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha);
    }
}
