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
    public class ProdutoGrupoDufryDapperRepository : Common.Repository, IProdutoGrupoDufryReadOnlyRepository
    {
        public ProdutoGrupoDufry Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var produtoGrupoDufrys = cn.Query<ProdutoGrupoDufry>("SELECT * FROM DimProdutoGrupoDufry WHERE Id_ProdutoGrupoDufry = @Id_ProdutoGrupoDufry",
                    new { ProdutoGrupoDufryKey = id }).FirstOrDefault();
                return produtoGrupoDufrys;
            }
        }

        public IEnumerable<ProdutoGrupoDufry> All()
        {
            using (var cn = BIVendasConnection)
            {
                var produtoGrupoDufrys = cn.Query<ProdutoGrupoDufry>("SELECT * FROM DimProdutoGrupoDufry");
                return produtoGrupoDufrys;
            }
        }

        public IEnumerable<ProdutoGrupoDufry> Find(Expression<Func<ProdutoGrupoDufry, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var produtoGrupoDufrys = cn.GetList<ProdutoGrupoDufry>(predicate);
                return produtoGrupoDufrys;
            }
        }
    }
}
