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
    public class ConfiguracaoDapperRepository : Common.Repository, IConfiguracaoReadOnlyRepository
    {
        public Configuracao Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var configuracao = cn.Query<Configuracao>
                    ("SELECT * " +
                     "FROM COMIS_CONFIGURACAO CON " +
                     "WHERE CAT.ID_CONFIGURACAO = @ID_CONFIGURACAO",
                        new { ID_CONFIGURACAO = id }).FirstOrDefault();
                return configuracao;
            }
        }

        public IEnumerable<Configuracao> All()
        {
            using (var cn = ComissoesConnection)
            {
                var configuracaos = cn.Query<Configuracao>
                    ("SELECT * " +
                     "FROM COMIS_CONFIGURACAO CON ");
                return configuracaos;
            }
        }

        public IEnumerable<Configuracao> Find(Expression<Func<Configuracao, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var configuracaos = cn.GetList<Configuracao>(predicate);
                return configuracaos;
            }
        }
    }
}
