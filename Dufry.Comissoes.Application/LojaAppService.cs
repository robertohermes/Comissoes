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
    public class LojaAppService : AppService<BIVendasContext>, ILojaAppService
    {
        private readonly ILojaService _service;

        public LojaAppService(ILojaService LojaService)
        {
            _service = LojaService;
        }

        public ValidationResult Create(Loja Loja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(Loja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Loja Loja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(Loja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Loja Loja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(Loja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Loja Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Loja> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Loja> Find(Expression<Func<Loja, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
