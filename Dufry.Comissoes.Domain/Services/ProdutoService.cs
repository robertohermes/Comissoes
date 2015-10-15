using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;
using System;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Services
{
    public class ProdutoService : Service<Produto>, IProdutoService
    {
        private readonly IProdutoReadOnlyRepository _readOnlyRepository;
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository, IProdutoReadOnlyRepository readOnlyRepository, IProdutoReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }

        public IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim)
        {
            //Acesso através do Dapper
            return _readOnlyRepository.InterfaceTransferPricing(dtIni, dtFim);

        }


        public IEnumerable<FolhaPagamento> InterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha)
        {
            //Acesso através do Dapper
            return _readOnlyRepository.InterfaceFolhaPagamento(CodigoFolha, CodigoLojaAlternate, CodigoClienteADP, NumeroProcessoFolha);

        }

    }
}
