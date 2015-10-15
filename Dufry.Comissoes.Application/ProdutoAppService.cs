using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Data.Context;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Application
{
    public class ProdutoAppService : AppService<BIVendasContext>, IProdutoAppService
    {
        private readonly IProdutoService _service;

        public ProdutoAppService(IProdutoService produtoService)
        {
            _service = produtoService;
        }

        public ValidationResult Create(Produto produto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(produto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Produto produto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(produto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Produto produto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(produto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Produto Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Produto> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Produto> Find(Expression<Func<Produto, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim)
        {
            return _service.InterfaceTransferPricing(dtIni, dtFim);
        }

        public IEnumerable<FolhaPagamento> InterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha)
        {
            return _service.InterfaceFolhaPagamento(CodigoFolha, CodigoLojaAlternate, CodigoClienteADP, NumeroProcessoFolha);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
