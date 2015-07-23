using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class ControleAcessoService : Service<ControleAcesso>, IControleAcessoService
    {
        private readonly IControleAcessoReadOnlyRepository _readOnlyRepository;
        private readonly IControleAcessoRepository _repository;
        public ControleAcessoService(IControleAcessoRepository repository, IControleAcessoReadOnlyRepository readOnlyRepository, IControleAcessoReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }

        //public ControleAcessoService(IControleAcessoRepository repository, IControleAcessoReadOnlyRepository readOnlyRepository) 
        //    : base(repository, readOnlyRepository)
        //{
        //}

        public ControleAcesso GetFirstLogin()
        {
            //Acesso através do Dapper
            return _readOnlyRepository.GetFirstLogin();
        }

        public ControleAcesso FindByActiveLogin(string login)
        {
            //Acesso através do Dapper
            //return _readOnlyRepository.FindByActiveLogin(login);

            //Acesso através do EntityFramework
            return _repository.FindByActiveLogin(login);
        }

    }
}
