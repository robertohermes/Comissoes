using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;

namespace Dufry.Comissoes.Application.Interfaces
{
    public interface IColaboradorAppService : IAppService<Colaborador>
    {
        IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO();

        IEnumerable<dynamic> All_ID();

        IEnumerable<dynamic> GET_ID(string CodigoEmpresaAlternate, string CodigoFilialAlternate, string CodigoSecundario);
    }
}
