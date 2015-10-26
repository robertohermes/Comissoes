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
    public class FilialDapperRepository : Common.Repository, IFilialReadOnlyRepository
    {
        public Filial Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.Query<Filial>("SELECT * FROM DimFilial WHERE Id_Filial = @Id_Filial",
                    new { FilialKey = id }).FirstOrDefault();
                return filiais;
            }
        }

        public IEnumerable<Filial> All()
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.Query<Filial>("SELECT * FROM DimFilial");
                return filiais;
            }
        }

        public IEnumerable<Filial> Find(Expression<Func<Filial, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.GetList<Filial>(predicate);
                return filiais;
            }
        }
    }
}
