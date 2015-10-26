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
    public class TipoNegocioDapperRepository : Common.Repository, ITipoNegocioReadOnlyRepository
    {
        public TipoNegocio Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var tipoNegocios = cn.Query<TipoNegocio>("SELECT * FROM DimTipoNegocio WHERE Id_TipoNegocio = @Id_TipoNegocio",
                    new { TipoNegocioKey = id }).FirstOrDefault();
                return tipoNegocios;
            }
        }

        public IEnumerable<TipoNegocio> All()
        {
            using (var cn = BIVendasConnection)
            {
                var tipoNegocios = cn.Query<TipoNegocio>("SELECT * FROM DimTipoNegocio");
                return tipoNegocios;
            }
        }

        public IEnumerable<TipoNegocio> Find(Expression<Func<TipoNegocio, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var tipoNegocios = cn.GetList<TipoNegocio>(predicate);
                return tipoNegocios;
            }
        }
    }
}
