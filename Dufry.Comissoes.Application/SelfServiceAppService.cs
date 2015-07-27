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
    public class SelfServiceAppService : AppService<ComissoesContext>, ISelfServiceAppService
    {
        private readonly ISelfServiceService _service;

        public SelfServiceAppService(ISelfServiceService selfserviceService)
        {
            _service = selfserviceService;
        }

        public ValidationResult Create(SelfService selfservice)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(selfservice));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(SelfService selfservice)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(selfservice));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(SelfService selfservice)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(selfservice));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public SelfService Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<SelfService> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<SelfService> Find(Expression<Func<SelfService, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
