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
    public class EmpresaAppService : AppService<BIVendasContext>, IEmpresaAppService
    {
        private readonly IEmpresaService _service;

        public EmpresaAppService(IEmpresaService EmpresaService)
        {
            _service = EmpresaService;
        }

        public ValidationResult Create(Empresa Empresa)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(Empresa));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Empresa Empresa)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(Empresa));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Empresa Empresa)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(Empresa));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Empresa Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Empresa> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
