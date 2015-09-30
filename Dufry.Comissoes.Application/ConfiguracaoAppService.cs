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
    public class ConfiguracaoAppService : AppService<ComissoesContext>, IConfiguracaoAppService
    {
        private readonly IConfiguracaoService _service;

        public ConfiguracaoAppService(IConfiguracaoService configuracaoService)
        {
            _service = configuracaoService;
        }

        public ValidationResult Create(Configuracao configuracao)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(configuracao));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Configuracao configuracao)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(configuracao));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Configuracao configuracao)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(configuracao));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Configuracao Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Configuracao> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Configuracao> Find(Expression<Func<Configuracao, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
