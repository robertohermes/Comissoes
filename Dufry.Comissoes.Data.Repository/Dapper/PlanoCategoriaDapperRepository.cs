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
    public class PlanoCategoriaDapperRepository : Common.Repository, IPlanoCategoriaReadOnlyRepository
    {
        public PlanoCategoria Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var controleacessos = cn.Query<PlanoCategoria>("SELECT * FROM COMIS_PLANO_CATEGORIA WHERE ID_PLANO = @id_plano",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return controleacessos;
            }
        }

        public IEnumerable<PlanoCategoria> All()
        {
            using (var cn = ComissoesConnection)
            {
                var controleacesso = cn.Query<PlanoCategoria>("SELECT * FROM COMIS_PLANO_CATEGORIA");
                return controleacesso;
            }
        }

        public IEnumerable<PlanoCategoria> Find(Expression<Func<PlanoCategoria, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var controleacessos = cn.GetList<PlanoCategoria>(predicate);
                return controleacessos;
            }
        }

    }
}
