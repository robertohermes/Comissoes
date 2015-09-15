using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Service
{
    public interface IPlanoCategoriaService : IService<PlanoCategoria>
    {
        void UpdateDapper(PlanoCategoria planoCategoria);
    }
}
