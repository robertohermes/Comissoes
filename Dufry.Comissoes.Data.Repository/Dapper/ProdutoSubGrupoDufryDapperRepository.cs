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
    public class ProdutoSubGrupoDufryDapperRepository : Common.Repository, IProdutoSubGrupoDufryReadOnlyRepository
    {
        public ProdutoSubGrupoDufry Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var produtoSubGrupoDufrys = cn.Query<ProdutoSubGrupoDufry>("SELECT * FROM DimProdutoSubGrupoDufry WHERE Id_ProdutoSubGrupoDufry = @Id_ProdutoSubGrupoDufry",
                    new { ProdutoSubGrupoDufryKey = id }).FirstOrDefault();
                return produtoSubGrupoDufrys;
            }
        }

        public IEnumerable<ProdutoSubGrupoDufry> All()
        {
            using (var cn = BIVendasConnection)
            {
                var produtoSubGrupoDufrys = cn.Query<ProdutoSubGrupoDufry>("SELECT * FROM DimProdutoSubGrupoDufry");
                return produtoSubGrupoDufrys;
            }
        }

        public IEnumerable<ProdutoSubGrupoDufry> Find(Expression<Func<ProdutoSubGrupoDufry, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var produtoSubGrupoDufrys = cn.GetList<ProdutoSubGrupoDufry>(predicate);
                return produtoSubGrupoDufrys;
            }
        }
    }
}
