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
    public class ProdutoCategoriaDapperRepository : Common.Repository, IProdutoCategoriaReadOnlyRepository
    {
        public ProdutoCategoria Get(int id)
        {
            using (var cn = BIVendasConnection)
            {
                var lojas = cn.Query<ProdutoCategoria>("SELECT * FROM DimProdutoCategoria WHERE Id_ProdutoCategoria = @Id_ProdutoCategoria",
                    new { ProdutoCategoriaKey = id }).FirstOrDefault();
                return lojas;
            }
        }

        public IEnumerable<ProdutoCategoria> All()
        {
            using (var cn = BIVendasConnection)
            {
                var produtoCategoria = cn.Query<ProdutoCategoria>("SELECT * FROM DimProdutoCategoria");
                return produtoCategoria;
            }
        }

        public IEnumerable<ProdutoCategoria> Find(Expression<Func<ProdutoCategoria, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var produtoCategorias = cn.GetList<ProdutoCategoria>(predicate);
                return produtoCategorias;
            }
        }
    }
}
