using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Validation;
using System.Collections.Generic;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface IPlanoCategoriaAppService : IAppService<PlanoCategoria>
    {
        ValidationResult CreateBatch(List<PlanoCategoria> planocategoriaList);

    }
}
