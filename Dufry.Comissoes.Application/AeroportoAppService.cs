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
    public class AeroportoAppService : AppService<BIVendasContext>, IAeroportoAppService
    {
        private readonly IAeroportoService _service;

        public AeroportoAppService(IAeroportoService aeroportoService)
        {
            _service = aeroportoService;
        }

        public ValidationResult Create(Aeroporto aeroporto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(aeroporto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Aeroporto aeroporto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(aeroporto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Aeroporto aeroporto)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(aeroporto));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Aeroporto Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Aeroporto> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Aeroporto> Find(Expression<Func<Aeroporto, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
