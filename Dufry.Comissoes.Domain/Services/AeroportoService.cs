using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class AeroportoService : Service<Aeroporto>, IAeroportoService
    {
        private readonly IAeroportoReadOnlyRepository _readOnlyRepository;
        private readonly IAeroportoRepository _repository;

        public AeroportoService(IAeroportoRepository repository, IAeroportoReadOnlyRepository readOnlyRepository, IAeroportoReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
