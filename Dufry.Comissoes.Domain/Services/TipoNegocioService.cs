using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class TipoNegocioService : Service<TipoNegocio>, ITipoNegocioService
    {
        private readonly ITipoNegocioReadOnlyRepository _readOnlyRepository;
        private readonly ITipoNegocioRepository _repository;

        public TipoNegocioService(ITipoNegocioRepository repository, ITipoNegocioReadOnlyRepository readOnlyRepository, ITipoNegocioReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
