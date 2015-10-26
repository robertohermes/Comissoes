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
    public class CategoriaDapperRepository : Common.Repository, ICategoriaReadOnlyRepository
    {
        public Categoria Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var categorias = cn.Query<Categoria>
                    ("SELECT * " +
                     "FROM COMIS_CATEGORIA CAT " +
                     "WHERE CAT.ID_CATEGORIA = @ID_CATEGORIA",
                        new { CategoriaKey = id }).FirstOrDefault();
                return categorias;
            }
        }

        public IEnumerable<Categoria> All()
        {
            using (var cn = ComissoesConnection)
            {
                var categorias = cn.Query<Categoria>
                    ("SELECT * " +
                     "FROM COMIS_CATEGORIA CAT ");
                return categorias;
            }
        }

        public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var categorias = cn.GetList<Categoria>(predicate);
                return categorias;
            }
        }
    }
}
