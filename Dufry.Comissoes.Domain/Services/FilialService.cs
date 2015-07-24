using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class FilialService : Service<Filial>, IFilialService
    {
        private readonly IFilialReadOnlyRepository _readOnlyRepository;
        private readonly IFilialRepository _repository;

        public FilialService(IFilialRepository repository, IFilialReadOnlyRepository readOnlyRepository, IFilialReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
