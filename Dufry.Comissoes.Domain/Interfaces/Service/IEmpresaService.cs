using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Service
{
    public interface IEmpresaService : IService<Empresa>
    {
        IEnumerable<Empresa> AllConcatCodigoEmpresaLegado();
    }
}
