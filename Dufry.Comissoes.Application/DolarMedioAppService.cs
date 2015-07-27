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
    public class DolarMedioAppService : AppService<ComissoesContext>, IDolarMedioAppService
    {
        private readonly IDolarMedioService _service;

        public DolarMedioAppService(IDolarMedioService dolarmedioService)
        {
            _service = dolarmedioService;
        }

        public ValidationResult Create(DolarMedio dolarmedio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(dolarmedio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(DolarMedio dolarmedio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(dolarmedio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(DolarMedio dolarmedio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(dolarmedio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public DolarMedio Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<DolarMedio> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<DolarMedio> Find(Expression<Func<DolarMedio, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
