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
    public class AeroportoDapperRepository : Common.Repository, IAeroportoReadOnlyRepository
    {
        public Aeroporto Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var aeroportos = cn.Query<Aeroporto>("SELECT * FROM DimAeroporto WHERE Id_Aeroporto = @Id_Aeroporto",
                    new { AeroportoKey = id }).FirstOrDefault();
                return aeroportos;
            }
        }

        public IEnumerable<Aeroporto> All()
        {
            using (var cn = BIVendasConnection)
            {
                var tiponegocio = cn.Query<Aeroporto>("SELECT * FROM DimAeroporto");
                return tiponegocio;
            }
        }

        public IEnumerable<Aeroporto> Find(Expression<Func<Aeroporto, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var aeroportos = cn.GetList<Aeroporto>(predicate);
                return aeroportos;
            }
        }
    }
}
