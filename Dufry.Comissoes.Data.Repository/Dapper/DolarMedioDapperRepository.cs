using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;

namespace Dufry.Comissoes.Data.Repository.Dapper
{
    public class DolarMedioDapperRepository : Common.Repository, IDolarMedioReadOnlyRepository
    {
        public DolarMedio Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                //<REVER>
                var dolarMedios = cn.Query<DolarMedio>("SELECT * FROM COMIS_DOLAR_MEDIO WHERE ID_PLANO = @id_plano",
                    new { ID_DOLAR_MEDIO = id }).FirstOrDefault();
                return dolarMedios;
            }
        }

        public IEnumerable<DolarMedio> All()
        {
            using (var cn = ComissoesConnection)
            {
                var dolarMedios = cn.Query<DolarMedio>("SELECT * FROM COMIS_DOLAR_MEDIO");
                return dolarMedios;
            }
        }

        public IEnumerable<DolarMedio> Find(Expression<Func<DolarMedio, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var dolarMedios = cn.GetList<DolarMedio>(predicate);
                return dolarMedios;
            }
        }

    }
}
