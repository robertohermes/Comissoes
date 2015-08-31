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
    public class EmpresaDapperRepository : Common.Repository, IEmpresaReadOnlyRepository
    {
        public Empresa Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var empresas = cn.Query<Empresa>("SELECT * FROM DimEmpresa WHERE Id_Empresa = @Id_Empresa",
                    new { EmpresaKey = id }).FirstOrDefault();
                return empresas;
            }
        }

        public IEnumerable<Empresa> All()
        {
            using (var cn = BIVendasConnection)
            {
                var empresa = cn.Query<Empresa>("SELECT * FROM DimEmpresa");
                return empresa;
            }
        }

        public IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var empresas = cn.GetList<Empresa>(predicate);
                return empresas;
            }
        }
    }
}
