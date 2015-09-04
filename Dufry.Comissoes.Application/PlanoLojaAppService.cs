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
    public class PlanoLojaAppService : AppService<ComissoesContext>, IPlanoLojaAppService
    {
        private readonly IPlanoLojaService _service;

        public PlanoLojaAppService(IPlanoLojaService planolojaService)
        {
            _service = planolojaService;
        }

        public ValidationResult Create(PlanoLoja planoloja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(planoloja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(PlanoLoja planoloja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(planoloja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(PlanoLoja planoloja)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(planoloja));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public PlanoLoja Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<PlanoLoja> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<PlanoLoja> Find(Expression<Func<PlanoLoja, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
