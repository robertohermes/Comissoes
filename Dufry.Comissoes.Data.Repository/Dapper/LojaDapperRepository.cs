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
    public class LojaDapperRepository : Common.Repository, ILojaReadOnlyRepository
    {
        public Loja Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.Query<Loja>("SELECT * FROM DimLoja WHERE Id_Loja = @Id_Loja",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return filiais;
            }
        }

        public IEnumerable<Loja> All()
        {
            using (var cn = BIVendasConnection)
            {
                var filial = cn.Query<Loja>("SELECT * FROM DimLoja");
                return filial;
            }
        }

        public IEnumerable<Loja> Find(Expression<Func<Loja, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.GetList<Loja>(predicate);
                return filiais;
            }
        }
    }
}
