using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class AusenciaRemuneradaService : Service<AusenciaRemunerada>, IAusenciaRemuneradaService
    {
        private readonly IAusenciaRemuneradaReadOnlyRepository _readOnlyRepository;
        private readonly IAusenciaRemuneradaRepository _repository;
        public AusenciaRemuneradaService(IAusenciaRemuneradaRepository repository, IAusenciaRemuneradaReadOnlyRepository readOnlyRepository, IAusenciaRemuneradaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
