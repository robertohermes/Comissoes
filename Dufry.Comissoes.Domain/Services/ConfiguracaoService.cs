using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class ConfiguracaoService : Service<Configuracao>, IConfiguracaoService
    {
        private readonly IConfiguracaoReadOnlyRepository _readOnlyRepository;
        private readonly IConfiguracaoRepository _repository;
        public ConfiguracaoService(IConfiguracaoRepository repository, IConfiguracaoReadOnlyRepository readOnlyRepository, IConfiguracaoReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
