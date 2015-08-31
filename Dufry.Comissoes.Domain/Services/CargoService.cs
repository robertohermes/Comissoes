using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class CargoService : Service<Cargo>, ICargoService
    {
        private readonly ICargoReadOnlyRepository _readOnlyRepository;
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository, ICargoReadOnlyRepository readOnlyRepository, ICargoReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
