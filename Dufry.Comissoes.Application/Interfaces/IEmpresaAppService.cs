using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface  IEmpresaAppService : IAppService<Empresa>
    {
        IEnumerable<Empresa> AllConcatCodigoEmpresaLegado();
    }
}
