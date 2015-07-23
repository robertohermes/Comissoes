using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class CategoriaService : Service<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository, ICategoriaReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
