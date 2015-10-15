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

        public IEnumerable<FolhaPagamento> InterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha)
        {
            //<REVER>
            string command = string.Concat("select COD_FOLHA, COD_EMPRESA, MATRICULA, COD_CLIENTE, PROCESSO_FOLHA, VALOR_LANCAMENTO "
                                          , "from ( "
                                          , "   SELECT '620' as COD_FOLHA, '003' AS COD_EMPRESA, '10033' AS MATRICULA, '1514' AS COD_CLIENTE, '5082' AS PROCESSO_FOLHA, 1117.27 AS VALOR_LANCAMENTO "
                                          , "   union "
                                          , "   SELECT '620' as COD_FOLHA, '003' AS COD_EMPRESA, '1007' AS MATRICULA, '1514' AS COD_CLIENTE, '5082' AS PROCESSO_FOLHA, 3.97 AS VALOR_LANCAMENTO "
                                          , "   union "
                                          , "   SELECT '620' as COD_FOLHA, '003' AS COD_EMPRESA, '10154' AS MATRICULA, '1514' AS COD_CLIENTE, '5082' AS PROCESSO_FOLHA, 821.78 AS VALOR_LANCAMENTO "
                                          , "   union "
                                          , "   SELECT '500' as COD_FOLHA, '003' AS COD_EMPRESA, '10157' AS MATRICULA, '1514' AS COD_CLIENTE, '5082' AS PROCESSO_FOLHA, 1188.42 AS VALOR_LANCAMENTO "
                                          , "   union "
                                          , "   SELECT '500' as COD_FOLHA, '003' AS COD_EMPRESA, '10192' AS MATRICULA, '1514' AS COD_CLIENTE, '5082' AS PROCESSO_FOLHA, 0.58 AS VALOR_LANCAMENTO "
                                          , ") IFP "
                                          , "where IFP.COD_FOLHA = @CodigoFolha ");

            using (var cn = BIVendasConnection)
            {
                var ifp = cn.Query<FolhaPagamento>(command, new { CodigoFolha = CodigoFolha
                                                                 });
                return ifp;
            }
        }

        public IEnumerable<TransferPricing> InterfaceTransferPricing(DateTime dtIni, DateTime dtFim)
        {

            //<REVER>
            string command = string.Concat("select COD_PRODUTO, NEGOCIO,  MES, VLR_DOLAR, VLR_REAL, COD_EMPRESA "
                                          , "from ( "
                                          , "   select '0000019' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 598.4743968 as VLR_DOLAR, 1423.74 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000035' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 379.80279936 as VLR_DOLAR, 904.37 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000051' as COD_PRODUTO, 'DF' as NEGOCIO,  '2014/01/31' as MES, 230.4028416 as VLR_DOLAR, 548.4 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000078' as COD_PRODUTO, 'DF' as NEGOCIO,  '2015/10/15' as MES, 68.03518464 as VLR_DOLAR, 163.39 as VLR_REAL, '003' as COD_EMPRESA "
                                          , "   union "
                                          , "   select '0000086' as COD_PRODUTO, 'DF' as NEGOCIO,  '2015/10/20' as MES, 1.32692736 as VLR_DOLAR, 3.15 as VLR_REAL, '003' as COD_EMPRESA "
                                          , ") ITP "
                                          , "where ITP.MES Between @dtIni AND @dtFim ");

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
