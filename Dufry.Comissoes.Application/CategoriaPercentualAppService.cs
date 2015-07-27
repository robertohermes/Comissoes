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
    public class CategoriaPercentualAppService : AppService<ComissoesContext>, ICategoriaPercentualAppService
    {
        private readonly ICategoriaPercentualService _service;

        public CategoriaPercentualAppService(ICategoriaPercentualService categoriapercentualService)
        {
            _service = categoriapercentualService;
        }

        public ValidationResult Create(CategoriaPercentual categoriapercentual)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(categoriapercentual));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(CategoriaPercentual categoriapercentual)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(categoriapercentual));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(CategoriaPercentual categoriapercentual)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(categoriapercentual));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public CategoriaPercentual Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<CategoriaPercentual> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<CategoriaPercentual> Find(Expression<Func<CategoriaPercentual, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
