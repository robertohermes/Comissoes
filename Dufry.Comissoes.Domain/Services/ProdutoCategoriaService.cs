using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class ProdutoCategoriaService : Service<ProdutoCategoria>, IProdutoCategoriaService
    {
        private readonly IProdutoCategoriaReadOnlyRepository _readOnlyRepository;
        private readonly IProdutoCategoriaRepository _repository;

        public ProdutoCategoriaService(IProdutoCategoriaRepository repository, IProdutoCategoriaReadOnlyRepository readOnlyRepository, IProdutoCategoriaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


    }
}
