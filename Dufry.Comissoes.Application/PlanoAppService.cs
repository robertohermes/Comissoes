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
    public class PlanoAppService : AppService<ComissoesContext>, IPlanoAppService
    {
        private readonly IPlanoService _service;

        public PlanoAppService(IPlanoService planoService)
        {
            _service = planoService;
        }

        public ValidationResult Create(Plano plano)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(plano));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Plano plano)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(plano));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Plano plano)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(plano));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Plano Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Plano> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Plano> Find(Expression<Func<Plano, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
