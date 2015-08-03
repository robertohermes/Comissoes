﻿using System;
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
                var filiais = cn.Query<Colaborador>("SELECT * FROM DimColaborador WHERE Id_Colaborador = @Id_Colaborador",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return filiais;
            }
        }

        public IEnumerable<Colaborador> All()
        {
            using (var cn = BIVendasConnection)
            {
                var filial = cn.Query<Colaborador>("SELECT * FROM DimColaborador");
                return filial;
            }
        }

        public IEnumerable<Colaborador> Find(Expression<Func<Colaborador, bool>> predicate)
        {
            using (var cn = BIVendasConnection)
            {
                var filiais = cn.GetList<Colaborador>(predicate);
                return filiais;
            }
        }
    }
}