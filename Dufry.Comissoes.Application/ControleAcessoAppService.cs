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
    public class ControleAcessoAppService : AppService<ComissoesContext>, IControleAcessoAppService
    {
        private readonly IControleAcessoService _service;

        public ControleAcessoAppService(IControleAcessoService controleacessoService)
        {
            _service = controleacessoService;
        }

        public ValidationResult Create(ControleAcesso controleacesso)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(controleacesso));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(ControleAcesso controleacesso)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(controleacesso));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(ControleAcesso controleacesso)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(controleacesso));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ControleAcesso Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<ControleAcesso> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<ControleAcesso> Find(Expression<Func<ControleAcesso, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public ControleAcesso GetFirstLogin()
        {
            return _service.GetFirstLogin();
        }

        public ControleAcesso FindByActiveLogin(string login)
        {
            return _service.FindByActiveLogin(login);
        }

        public string ObtainCurrentLoginFromAd()
        {

            string Name = System.Environment.UserName;

            #region alternativas
            //string Name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            //ou
            //string Name = Environment.GetEnvironmentVariable("USERNAME");
            //ou
            //string Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            #endregion alternativas

            return Name;
        }

        public ControleAcesso Get_FilhosDiretos(int id)
        {
            return _service.Get_FilhosDiretos(id);
        }

        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
