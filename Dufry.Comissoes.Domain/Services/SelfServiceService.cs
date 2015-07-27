using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class SelfServiceService : Service<SelfService>, ISelfServiceService
    {
        private readonly ISelfServiceReadOnlyRepository _readOnlyRepository;
        private readonly ISelfServiceRepository _repository;
        public SelfServiceService(ISelfServiceRepository repository, ISelfServiceReadOnlyRepository readOnlyRepository, ISelfServiceReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
