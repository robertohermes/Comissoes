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
    public class ProdutoGrupoDufryAppService : AppService<BIVendasContext>, IProdutoGrupoDufryAppService
    {
        private readonly IProdutoGrupoDufryService _service;

        public ProdutoGrupoDufryAppService(IProdutoGrupoDufryService produtoGrupoDufryService)
        {
            _service = produtoGrupoDufryService;
        }

        public ValidationResult Create(ProdutoGrupoDufry produtoGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(produtoGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(ProdutoGrupoDufry produtoGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(produtoGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(ProdutoGrupoDufry produtoGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(produtoGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ProdutoGrupoDufry Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ProdutoGrupoDufry> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<ProdutoGrupoDufry> Find(Expression<Func<ProdutoGrupoDufry, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
