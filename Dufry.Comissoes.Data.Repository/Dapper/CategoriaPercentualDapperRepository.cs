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
    public class CategoriaPercentualDapperRepository : Common.Repository, ICategoriaPercentualReadOnlyRepository
    {
        public CategoriaPercentual Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var categoriaPercentuals = cn.Query<CategoriaPercentual>("SELECT * FROM COMIS_CATEGORIA_PERCENTUAL WHERE ID_CATEGORIA_PERCENTUAL = @id_categoria_percentual",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return categoriaPercentuals;
            }
        }

        public IEnumerable<CategoriaPercentual> All()
        {
            using (var cn = ComissoesConnection)
            {
                var categoriaPercentuals = cn.Query<CategoriaPercentual>("SELECT * FROM COMIS_CATEGORIA_PERCENTUAL");
                return categoriaPercentuals;
            }
        }

        public IEnumerable<CategoriaPercentual> Find(Expression<Func<CategoriaPercentual, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var categoriaPercentuals = cn.GetList<CategoriaPercentual>(predicate);
                return categoriaPercentuals;
            }
        }

    }
}
