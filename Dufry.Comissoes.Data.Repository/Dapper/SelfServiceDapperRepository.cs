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
    public class SelfServiceDapperRepository : Common.Repository, ISelfServiceReadOnlyRepository
    {
        public SelfService Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var selfServices = cn.Query<SelfService>("SELECT * FROM COMIS_SELF_SERVICE WHERE ID_SELF_SERVICE = @id_self_service",
                    new { SelfServiceKey = id }).FirstOrDefault();
                return selfServices;
            }
        }

        public IEnumerable<SelfService> All()
        {
            using (var cn = ComissoesConnection)
            {
                var selfServices = cn.Query<SelfService>("SELECT * FROM COMIS_SELF_SERVICE");
                return selfServices;
            }
        }

        public IEnumerable<SelfService> Find(Expression<Func<SelfService, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var selfServices = cn.GetList<SelfService>(predicate);
                return selfServices;
            }
        }

    }
}
