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
    public class CargoAppService : AppService<BIVendasContext>, ICargoAppService
    {
        private readonly ICargoService _service;

        public CargoAppService(ICargoService CargoService)
        {
            _service = CargoService;
        }

        public ValidationResult Create(Cargo Cargo)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(Cargo));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Cargo Cargo)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(Cargo));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Cargo Cargo)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(Cargo));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Cargo Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Cargo> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Cargo> Find(Expression<Func<Cargo, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
