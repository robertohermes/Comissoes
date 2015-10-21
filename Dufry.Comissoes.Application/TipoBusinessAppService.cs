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
    public class TipoBusinessAppService : AppService<BIVendasContext>, ITipoBusinessAppService
    {
        private readonly ITipoBusinessService _service;

        public TipoBusinessAppService(ITipoBusinessService tipoBusinessService)
        {
            _service = tipoBusinessService;
        }

        public ValidationResult Create(TipoBusiness tipoBusiness)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(tipoBusiness));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(TipoBusiness tipoBusiness)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(tipoBusiness));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(TipoBusiness tipoBusiness)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(tipoBusiness));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public TipoBusiness Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<TipoBusiness> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<TipoBusiness> Find(Expression<Func<TipoBusiness, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
