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
                var planos = cn.Query<Plano>("SELECT * FROM COMIS_PLANO WHERE ID_PLANO = @id_plano",
                    new { PlanoKey = id }).FirstOrDefault();
                return planos;
            }
        }

        public IEnumerable<Plano> All()
        {
            using (var cn = ComissoesConnection)
            {
                var planos = cn.Query<Plano>("SELECT * FROM COMIS_PLANO");
                return planos;
            }
        }

        public IEnumerable<Plano> Find(Expression<Func<Plano, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var planos = cn.GetList<Plano>(predicate);
                return planos;
            }
        }

    }
}
