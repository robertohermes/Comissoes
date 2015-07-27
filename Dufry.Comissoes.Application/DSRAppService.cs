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
    public class DSRAppService : AppService<ComissoesContext>, IDSRAppService
    {
        private readonly IDSRService _service;

        public DSRAppService(IDSRService dsrService)
        {
            _service = dsrService;
        }

        public ValidationResult Create(DSR dsr)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(dsr));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(DSR dsr)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(dsr));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(DSR dsr)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(dsr));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public DSR Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<DSR> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<DSR> Find(Expression<Func<DSR, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
