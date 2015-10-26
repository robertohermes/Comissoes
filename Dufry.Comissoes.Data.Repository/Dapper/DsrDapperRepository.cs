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
    public class DSRDapperRepository : Common.Repository, IDSRReadOnlyRepository
    {
        public DSR Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var dsrs = cn.Query<DSR>("SELECT * FROM COMIS_DSR WHERE ID_DSR = @id_dsr",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return dsrs;
            }
        }

        public IEnumerable<DSR> All()
        {
            using (var cn = ComissoesConnection)
            {
                var dsrs = cn.Query<DSR>("SELECT * FROM COMIS_DSR");
                return dsrs;
            }
        }

        public IEnumerable<DSR> Find(Expression<Func<DSR, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var dsrs = cn.GetList<DSR>(predicate);
                return dsrs;
            }
        }

    }
}
