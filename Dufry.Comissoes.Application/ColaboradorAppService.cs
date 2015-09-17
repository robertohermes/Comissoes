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
    public class ColaboradorAppService : AppService<BIVendasContext>, IColaboradorAppService
    {
        private readonly IColaboradorService _service;

        public ColaboradorAppService(IColaboradorService ColaboradorService)
        {
            _service = ColaboradorService;
        }

        public ValidationResult Create(Colaborador Colaborador)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(Colaborador));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Colaborador Colaborador)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(Colaborador));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Colaborador Colaborador)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(Colaborador));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Colaborador Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Colaborador> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Colaborador> Find(Expression<Func<Colaborador, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO()
        {
            return _service.All_ID_COMPOSTO();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
