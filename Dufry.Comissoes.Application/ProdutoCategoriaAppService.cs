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
    public class ProdutoCategoriaAppService : AppService<BIVendasContext>, IProdutoCategoriaAppService
    {
        private readonly IProdutoCategoriaService _service;

        public ProdutoCategoriaAppService(IProdutoCategoriaService produtoCategoriaService)
        {
            _service = produtoCategoriaService;
        }

        public ValidationResult Create(ProdutoCategoria produtoCategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(produtoCategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(ProdutoCategoria produtoCategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(produtoCategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(ProdutoCategoria produtoCategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(produtoCategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ProdutoCategoria Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ProdutoCategoria> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<ProdutoCategoria> Find(Expression<Func<ProdutoCategoria, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
