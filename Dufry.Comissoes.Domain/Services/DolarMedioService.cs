using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class DolarMedioService : Service<DolarMedio>, IDolarMedioService
    {
        private readonly IDolarMedioReadOnlyRepository _readOnlyRepository;
        private readonly IDolarMedioRepository _repository;
        public DolarMedioService(IDolarMedioRepository repository, IDolarMedioReadOnlyRepository readOnlyRepository, IDolarMedioReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
