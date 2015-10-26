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
    public class CargoDapperRepository : Common.Repository, ICargoReadOnlyRepository
    {
        public Cargo Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var cargos = cn.Query<Cargo>("SELECT * FROM DimCargo WHERE Id_Cargo = @Id_Cargo",
                    new { CargoKey = id }).FirstOrDefault();
                return cargos;
            }
        }

        public IEnumerable<Cargo> All()
        {
            using (var cn = BIVendasConnection)
            {
                var cargos = cn.Query<Cargo>("SELECT * FROM DimCargo");
                return cargos;
            }
        }

        public IEnumerable<Cargo> Find(Expression<Func<Cargo, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var cargos = cn.GetList<Cargo>(predicate);
                return cargos;
            }
        }
    }
}
