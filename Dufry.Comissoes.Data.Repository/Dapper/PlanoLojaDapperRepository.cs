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
    public class PlanoLojaDapperRepository : Common.Repository, IPlanoLojaReadOnlyRepository
    {
        public PlanoLoja Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var planoLojas = cn.Query<PlanoLoja>("SELECT * FROM COMIS_PLANO_LOJA WHERE ID_PLANO_LOJA = @id_plano_loja",
                    new { PlanoLojaKey = id }).FirstOrDefault();
                return planoLojas;
            }
        }

        public IEnumerable<PlanoLoja> All()
        {
            using (var cn = ComissoesConnection)
            {
                var planoLojas = cn.Query<PlanoLoja>("SELECT * FROM COMIS_PLANO_LOJA");
                return planoLojas;
            }
        }

        public IEnumerable<PlanoLoja> Find(Expression<Func<PlanoLoja, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var planoLojas = cn.GetList<PlanoLoja>(predicate);
                return planoLojas;
            }
        }

    }
}
