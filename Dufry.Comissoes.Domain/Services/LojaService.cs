using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class LojaService : Service<Loja>, ILojaService
    {
        private readonly ILojaReadOnlyRepository _readOnlyRepository;
        private readonly ILojaRepository _repository;

        public LojaService(ILojaRepository repository, ILojaReadOnlyRepository readOnlyRepository, ILojaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
