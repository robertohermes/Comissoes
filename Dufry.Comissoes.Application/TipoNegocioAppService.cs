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
    public class TipoNegocioAppService : AppService<BIVendasContext>, ITipoNegocioAppService
    {
        private readonly ITipoNegocioService _service;

        public TipoNegocioAppService(ITipoNegocioService TipoNegocioService)
        {
            _service = TipoNegocioService;
        }

        public ValidationResult Create(TipoNegocio TipoNegocio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(TipoNegocio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(TipoNegocio TipoNegocio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(TipoNegocio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(TipoNegocio TipoNegocio)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(TipoNegocio));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public TipoNegocio Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<TipoNegocio> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<TipoNegocio> Find(Expression<Func<TipoNegocio, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
