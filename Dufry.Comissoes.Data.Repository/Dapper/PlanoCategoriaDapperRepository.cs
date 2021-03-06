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
    public class PlanoCategoriaDapperRepository : Common.Repository, IPlanoCategoriaReadOnlyRepository
    {
        public PlanoCategoria Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var planoCategorias = cn.Query<PlanoCategoria>("SELECT * FROM COMIS_PLANO_CATEGORIA WHERE ID_PLANO_CATEGORIA = @id_plano_categoria",
                    new { PlanoCategoriaKey = id }).FirstOrDefault();
                return planoCategorias;
            }
        }

        public IEnumerable<PlanoCategoria> All()
        {
            using (var cn = ComissoesConnection)
            {
                var planoCategorias = cn.Query<PlanoCategoria>("SELECT * FROM COMIS_PLANO_CATEGORIA");
                return planoCategorias;
            }
        }

        public IEnumerable<PlanoCategoria> Find(Expression<Func<PlanoCategoria, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var planoCategorias = cn.GetList<PlanoCategoria>(predicate);
                return planoCategorias;
            }
        }

        public void Update(PlanoCategoria planoCategoria)
        {
            string command = string.Concat("UPDATE "
                                        , "COMIS_PLANO_CATEGORIA "
                                        , "SET "
                                        , "ORDEM_HIERARQUIA = @ORDEM_HIERARQUIA, "
                                        , "LAST_MODIFY_DATE = @LAST_MODIFY_DATE, "
                                        , "LAST_MODIFY_USERNAME = @LAST_MODIFY_USERNAME "
                                        , "WHERE "
                                        , "ID_PLANO_CATEGORIA = @ID_PLANO_CATEGORIA");

            using (var cn = ComissoesConnection)
            {
                var planocategoria = cn.ExecuteScalar(command, new
                {
                    ORDEM_HIERARQUIA = planoCategoria.ORDEM_HIERARQUIA
                  , LAST_MODIFY_DATE = planoCategoria.LAST_MODIFY_DATE
                  , LAST_MODIFY_USERNAME = planoCategoria.LAST_MODIFY_USERNAME
                  , ID_PLANO_CATEGORIA = planoCategoria.ID_PLANO_CATEGORIA
                });
            }
        }

        public void Insert(PlanoCategoria planoCategoria)
        {
            string command = string.Concat("INSERT "
                                        , "COMIS_PLANO_CATEGORIA "
                                        , "(ID_PLANO, ID_CATEGORIA, ORDEM_HIERARQUIA, CREATED_DATETIME, CREATED_USERNAME, LAST_MODIFY_DATE, LAST_MODIFY_USERNAME) "
                                        , "Values "
                                        , "(@ID_PLANO, @ID_CATEGORIA, @ORDEM_HIERARQUIA, @CREATED_DATETIME, @CREATED_USERNAME, @LAST_MODIFY_DATE, @LAST_MODIFY_USERNAME)"
                                        );

            using (var cn = ComissoesConnection)
            {
                var planocategoria = cn.ExecuteScalar(command, new
                {
                    ID_PLANO = planoCategoria.ID_PLANO
                  , ID_CATEGORIA = planoCategoria.ID_CATEGORIA
                  , ORDEM_HIERARQUIA = planoCategoria.ORDEM_HIERARQUIA
                  , CREATED_DATETIME = planoCategoria.CREATED_DATETIME
                  , CREATED_USERNAME = planoCategoria.CREATED_USERNAME
                  , LAST_MODIFY_DATE = planoCategoria.LAST_MODIFY_DATE
                  , LAST_MODIFY_USERNAME = planoCategoria.LAST_MODIFY_USERNAME
                });
            }
        }

        public void Delete(PlanoCategoria planoCategoria)
        {
            string command = string.Concat("DELETE FROM "
                                        , "COMIS_PLANO_CATEGORIA "
                                        , "WHERE "
                                        , "ID_PLANO_CATEGORIA = @ID_PLANO_CATEGORIA");

            using (var cn = ComissoesConnection)
            {
                var planocategoria = cn.ExecuteScalar(command, new
                {
                    ID_PLANO_CATEGORIA = planoCategoria.ID_PLANO_CATEGORIA
                });
            }
        }

    }
}
