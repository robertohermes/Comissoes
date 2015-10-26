using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class ProdutoGrupoDufryService : Service<ProdutoGrupoDufry>, IProdutoGrupoDufryService
    {
        private readonly IProdutoGrupoDufryReadOnlyRepository _readOnlyRepository;
        private readonly IProdutoGrupoDufryRepository _repository;

        public ProdutoGrupoDufryService(IProdutoGrupoDufryRepository repository, IProdutoGrupoDufryReadOnlyRepository readOnlyRepository, IProdutoGrupoDufryReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
