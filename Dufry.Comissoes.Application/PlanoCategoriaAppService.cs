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
    public class PlanoCategoriaAppService : AppService<ComissoesContext>, IPlanoCategoriaAppService
    {
        private readonly IPlanoCategoriaService _service;

        public PlanoCategoriaAppService(IPlanoCategoriaService planocategoriaService)
        {
            _service = planocategoriaService;
        }

        public ValidationResult Create(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult CreateBatch(List<PlanoCategoria> planocategoriaList)
        {
            BeginTransaction();

            foreach (PlanoCategoria planocategoria in planocategoriaList)
            {
                ValidationResult.Add(_service.Add(planocategoria));                
            }

            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public PlanoCategoria Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<PlanoCategoria> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<PlanoCategoria> Find(Expression<Func<PlanoCategoria, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
