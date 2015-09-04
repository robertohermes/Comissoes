using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class PlanoLojaService : Service<PlanoLoja>, IPlanoLojaService
    {
        private readonly IPlanoLojaReadOnlyRepository _readOnlyRepository;
        private readonly IPlanoLojaRepository _repository;
        public PlanoLojaService(IPlanoLojaRepository repository, IPlanoLojaReadOnlyRepository readOnlyRepository, IPlanoLojaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
