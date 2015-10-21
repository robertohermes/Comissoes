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
    public class TipoBusinessDapperRepository : Common.Repository, ITipoBusinessReadOnlyRepository
    {
        public TipoBusiness Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var tiponegocios = cn.Query<TipoBusiness>("SELECT * FROM DimTipoBusiness WHERE Id_TipoBusiness = @Id_TipoBusiness",
                    new { TipoNegocioKey = id }).FirstOrDefault();
                return tiponegocios;
            }
        }

        public IEnumerable<TipoBusiness> All()
        {
            using (var cn = BIVendasConnection)
            {
                var tipoBusiness = cn.Query<TipoBusiness>("SELECT * FROM DimTipoBusiness");
                return tipoBusiness;
            }
        }

        public IEnumerable<TipoBusiness> Find(Expression<Func<TipoBusiness, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var tipoBusineses = cn.GetList<TipoBusiness>(predicate);
                return tipoBusineses;
            }
        }
    }
}
