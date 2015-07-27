using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class CategoriaPercentualService : Service<CategoriaPercentual>, ICategoriaPercentualService
    {
        private readonly ICategoriaPercentualReadOnlyRepository _readOnlyRepository;
        private readonly ICategoriaPercentualRepository _repository;
        public CategoriaPercentualService(ICategoriaPercentualRepository repository, ICategoriaPercentualReadOnlyRepository readOnlyRepository, ICategoriaPercentualReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
