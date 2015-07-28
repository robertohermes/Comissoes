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
    public class PlanoDapperRepository : Common.Repository, IPlanoReadOnlyRepository
    {
        public Plano Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var controleacessos = cn.Query<Plano>("SELECT * FROM COMIS_PLANO WHERE ID_PLANO = @id_plano",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return controleacessos;
            }
        }

        public IEnumerable<Plano> All()
        {
            using (var cn = ComissoesConnection)
            {
                var controleacesso = cn.Query<Plano>("SELECT * FROM COMIS_PLANO");
                return controleacesso;
            }
        }

        public IEnumerable<Plano> Find(Expression<Func<Plano, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var controleacessos = cn.GetList<Plano>(predicate);
                return controleacessos;
            }
        }

    }
}
