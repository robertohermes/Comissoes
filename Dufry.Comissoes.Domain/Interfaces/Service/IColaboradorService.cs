using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Interfaces.Service
{
    public interface IColaboradorService : IService<Colaborador>
    {
        IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO();

        IEnumerable<dynamic> All_ID();

        IEnumerable<dynamic> GET_ID(string CodigoEmpresaAlternate, string CodigoFilialAlternate, string CodigoSecundario);
    }
}
