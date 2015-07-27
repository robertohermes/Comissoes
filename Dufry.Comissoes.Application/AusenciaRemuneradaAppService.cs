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
    public class AusenciaRemuneradaAppService : AppService<ComissoesContext>, IAusenciaRemuneradaAppService
    {
        private readonly IAusenciaRemuneradaService _service;

        public AusenciaRemuneradaAppService(IAusenciaRemuneradaService ausenciaremuneradaService)
        {
            _service = ausenciaremuneradaService;
        }

        public ValidationResult Create(AusenciaRemunerada ausenciaremunerada)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(ausenciaremunerada));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(AusenciaRemunerada ausenciaremunerada)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(ausenciaremunerada));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(AusenciaRemunerada ausenciaremunerada)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(ausenciaremunerada));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public AusenciaRemunerada Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<AusenciaRemunerada> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<AusenciaRemunerada> Find(Expression<Func<AusenciaRemunerada, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
