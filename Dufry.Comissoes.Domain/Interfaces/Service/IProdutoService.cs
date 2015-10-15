using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using System;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Service
{
    public interface IProdutoService : IService<Produto>
    {
        IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim);

        IEnumerable<FolhaPagamento> InterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha);
    }
}
