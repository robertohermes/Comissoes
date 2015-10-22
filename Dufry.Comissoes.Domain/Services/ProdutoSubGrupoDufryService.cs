using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class ProdutoSubGrupoDufryService : Service<ProdutoSubGrupoDufry>, IProdutoSubGrupoDufryService
    {
        private readonly IProdutoSubGrupoDufryReadOnlyRepository _readOnlyRepository;
        private readonly IProdutoSubGrupoDufryRepository _repository;

        public ProdutoSubGrupoDufryService(IProdutoSubGrupoDufryRepository repository, IProdutoSubGrupoDufryReadOnlyRepository readOnlyRepository, IProdutoSubGrupoDufryReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
