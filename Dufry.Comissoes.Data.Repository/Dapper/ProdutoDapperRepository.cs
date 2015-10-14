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
    public class ProdutoDapperRepository : Common.Repository, IProdutoReadOnlyRepository
    {
        public Produto Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var produtos = cn.Query<Produto>("SELECT * FROM DimProduto WHERE Id_Produto = @Id_Produto",
                    new { ProdutoKey = id }).FirstOrDefault();
                return produtos;
            }
        }

        public IEnumerable<Produto> All()
        {
            using (var cn = BIVendasConnection)
            {
                var produto = cn.Query<Produto>("SELECT * FROM DimProduto");
                return produto;
            }
        }

        public IEnumerable<Produto> Find(Expression<Func<Produto, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var produtos = cn.GetList<Produto>(predicate);
                return produtos;
            }
        }

        public IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim)
        {
            //string command = string.Concat("select '0000019' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 598.4743968 as VLR_DOLAR, 1423.74 as VLR_REAL, '003' as COD_EMPRESA "
            //                              , "union "
            //                              , "select '0000035' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 379.80279936 as VLR_DOLAR, 904.37 as VLR_REAL, '003' as COD_EMPRESA "
            //                              , "union "
            //                              , "select '0000051' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 230.4028416 as VLR_DOLAR, 548.4 as VLR_REAL, '003' as COD_EMPRESA "
            //                              , "union "
            //                              , "select '0000078' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 68.03518464 as VLR_DOLAR, 163.39 as VLR_REAL, '003' as COD_EMPRESA "
            //                              , "union "
            //                              , "select '0000086' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 1.32692736 as VLR_DOLAR, 3.15 as VLR_REAL, '003' as COD_EMPRESA ");


            string command = string.Concat("select COD_PRODUTO, NEGOCIO,  MES, VLR_DOLAR, VLR_REAL, COD_EMPRESA "
                                          , "from ( "
                                          , "   select '0000019' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 598.4743968 as VLR_DOLAR, 1423.74 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000035' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 379.80279936 as VLR_DOLAR, 904.37 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000051' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 230.4028416 as VLR_DOLAR, 548.4 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000078' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/02/20' as MES, 68.03518464 as VLR_DOLAR, 163.39 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000086' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/03/15' as MES, 1.32692736 as VLR_DOLAR, 3.15 as VLR_REAL, '003' as COD_EMPRESA "
                                          , ") ITP "
                                          , "where ITP.MES Between  @dtIni AND  @dtFim ");

            using (var cn = BIVendasConnection)
            {
                var itp = cn.Query<TransferPricing>(command, new{ dtIni = dtIni
                                                                , dtFim = dtFim
                                                                });
                return itp;
            }
        }
    }
}
