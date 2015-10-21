using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class TipoBusinessService : Service<TipoBusiness>, ITipoBusinessService
    {
        private readonly ITipoBusinessReadOnlyRepository _readOnlyRepository;
        private readonly ITipoBusinessRepository _repository;

        public TipoBusinessService(ITipoBusinessRepository repository, ITipoBusinessReadOnlyRepository readOnlyRepository, ITipoBusinessReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
