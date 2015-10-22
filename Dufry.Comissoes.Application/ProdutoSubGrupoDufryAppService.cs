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
    public class ProdutoSubGrupoDufryAppService : AppService<BIVendasContext>, IProdutoSubGrupoDufryAppService
    {
        private readonly IProdutoSubGrupoDufryService _service;

        public ProdutoSubGrupoDufryAppService(IProdutoSubGrupoDufryService produtoSubGrupoDufryService)
        {
            _service = produtoSubGrupoDufryService;
        }

        public ValidationResult Create(ProdutoSubGrupoDufry produtoSubGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(produtoSubGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(ProdutoSubGrupoDufry produtoSubGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(produtoSubGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(ProdutoSubGrupoDufry produtoSubGrupoDufry)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(produtoSubGrupoDufry));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ProdutoSubGrupoDufry Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ProdutoSubGrupoDufry> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<ProdutoSubGrupoDufry> Find(Expression<Func<ProdutoSubGrupoDufry, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
