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
    public class FilialAppService : AppService<BIVendasContext>, IFilialAppService
    {
        private readonly IFilialService _service;

        public FilialAppService(IFilialService FilialService)
        {
            _service = FilialService;
        }

        public ValidationResult Create(Filial Filial)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(Filial));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Filial Filial)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(Filial));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Filial Filial)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(Filial));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Filial Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Filial> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Filial> Find(Expression<Func<Filial, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
