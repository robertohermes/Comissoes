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
    public class ColaboradorDapperRepository : Common.Repository, IColaboradorReadOnlyRepository
    {
        public Colaborador Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var colaboradores = cn.Query<Colaborador>("SELECT * FROM DimColaborador WHERE Id_Colaborador = @Id_Colaborador",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return colaboradores;
            }
        }

        public IEnumerable<Colaborador> All()
        {
            using (var cn = BIVendasConnection)
            {
                var colaborador = cn.Query<Colaborador>("SELECT * FROM DimColaborador");
                return colaborador;
            }
        }

        public IEnumerable<Colaborador> Find(Expression<Func<Colaborador, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var colaboradores = cn.GetList<Colaborador>(predicate);
                return colaboradores;
            }
        }

        public IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO()
        {
            string command = string.Concat("SELECT distinct top 100 "
                                          ,"cast(emp.CodigoEmpresaAlternate as nvarchar(20)) + '|' + fil.CodigoFilialAlternate + '|' + col.CodigoSecundario as COLABORADORKEY_ALT, col.NomeCompleto as NomeCompleto "
                                          ,"FROM        DimColaborador  col "
                                          ,"INNER JOIN  DimLoja         loj ON col.Id_Loja          = loj.Id_Loja "
                                          ,"INNER JOIN  DimFilial       fil on loj.Id_Filial        = fil.Id_Filial "
                                          ,"INNER JOIN  DimTipoNegocio  neg ON fil.Id_TipoNegocio   = neg.Id_TipoNegocio "
                                          ,"INNER JOIN  DimEmpresa      emp ON neg.Id_Empresa       = emp.Id_Empresa "
                                          , "ORDER BY NomeCompleto ");

            using (var cn = BIVendasConnection)
            {
                var colaborador = cn.Query(command).ToDictionary(row => (string)row.COLABORADORKEY_ALT,
                                                                 row => (string)row.NomeCompleto);
                return colaborador;
            }
        }

        public IEnumerable<dynamic> All_ID()
        {
            string command = string.Concat("SELECT distinct top 100 "
                                          , "cast(emp.CodigoEmpresaAlternate as nvarchar(20)) as CodigoEmpresaAlternate, "
                                          , "fil.CodigoFilialAlternate, "
                                          , "col.CodigoSecundario, "
                                          , "col.NomeCompleto "
                                          , "FROM        DimColaborador  col "
                                          , "INNER JOIN  DimLoja         loj ON col.Id_Loja          = loj.Id_Loja "
                                          , "INNER JOIN  DimFilial       fil on loj.Id_Filial        = fil.Id_Filial "
                                          , "INNER JOIN  DimTipoNegocio  neg ON fil.Id_TipoNegocio   = neg.Id_TipoNegocio "
                                          , "INNER JOIN  DimEmpresa      emp ON neg.Id_Empresa       = emp.Id_Empresa "
                                          , "ORDER BY NomeCompleto ");

            using (var cn = BIVendasConnection)
            {
                var result = cn.Query(command);
                return result;
            }
        }
    }
}
