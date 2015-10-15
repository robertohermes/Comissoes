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
                var empresa = cn.Query<Empresa>("SELECT * FROM DimEmpresa WHERE Id_Empresa = @Id_Empresa",
                    new { EmpresaKey = id }).FirstOrDefault();
                return empresa;
            }
        }

        public IEnumerable<Empresa> All()
        {
            using (var cn = BIVendasConnection)
            {
                var empresas = cn.Query<Empresa>("SELECT * FROM DimEmpresa");
                return empresas;
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

        public IEnumerable<Empresa> AllConcatCodigoEmpresaLegado()
        {
            string command = string.Concat("SELECT      distinct Emp.Id_Empresa, Emp.Id_Pais, Emp.CodigoEmpresaAlternate, "
                                         , "            Case when Tin.CodigoEmpresaLegado = '02' Then '003 - ' + Emp.NomeEmpresa "
                                         , "                 when Tin.CodigoEmpresaLegado = '20' Then '042 - ' + Emp.NomeEmpresa "
                                         , "                 Else '003 - ' +  + Emp.NomeEmpresa "
                                         , "            End as NomeEmpresa "
                                         , "FROM        DimEmpresa      Emp "
                                         , "INNER JOIN  DimTipoNegocio  Tin ON Emp.Id_Empresa = Tin.Id_Empresa "
                                         , "where       Emp.CodigoEmpresaAlternate not in (-1,-2)");

            using (var cn = BIVendasConnection)
            {
                var empresas = cn.Query<Empresa>(command);
                return empresas;
            }
        }

    }
}
