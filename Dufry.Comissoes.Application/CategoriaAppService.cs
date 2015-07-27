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
    public class CategoriaAppService : AppService<ComissoesContext>, ICategoriaAppService
    {
        private readonly ICategoriaService _service;

        public CategoriaAppService(ICategoriaService categoriaService)
        {
            _service = categoriaService;
        }

        public ValidationResult Create(Categoria categoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(categoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Categoria categoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(categoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Categoria categoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(categoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Categoria Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Categoria> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
