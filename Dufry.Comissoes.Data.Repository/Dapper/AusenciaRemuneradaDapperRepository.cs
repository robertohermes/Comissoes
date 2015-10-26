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
    public class AusenciaRemuneradaDapperRepository : Common.Repository, IAusenciaRemuneradaReadOnlyRepository
    {
        public AusenciaRemunerada Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var ausenciaRemuneradas = cn.Query<AusenciaRemunerada>("SELECT * FROM COMIS_AUSENCIA_REMUNERADA WHERE ID_AUSENCIA_REMUNERADA = @id_ausencia_remunerada",
                    new { AusenciaRemuneradaKey = id }).FirstOrDefault();
                return ausenciaRemuneradas;
            }
        }

        public IEnumerable<AusenciaRemunerada> All()
        {
            using (var cn = ComissoesConnection)
            {
                var ausenciaRemuneradas = cn.Query<AusenciaRemunerada>("SELECT * FROM COMIS_AUSENCIA_REMUNERADA");
                return ausenciaRemuneradas;
            }
        }

        public IEnumerable<AusenciaRemunerada> Find(Expression<Func<AusenciaRemunerada, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var ausenciaRemuneradas = cn.GetList<AusenciaRemunerada>(predicate);
                return ausenciaRemuneradas;
            }
        }

    }
}
