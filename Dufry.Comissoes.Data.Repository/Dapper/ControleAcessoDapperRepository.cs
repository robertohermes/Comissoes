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
    public class ControleAcessoDapperRepository : Common.Repository, IControleAcessoReadOnlyRepository
    {
        public ControleAcesso Get(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcessos = cn.Query<ControleAcesso>("SELECT * FROM COMIS_CONTROLE_ACESSO WHERE COLABORADORKEY = @ColaboradorKey",
                    new { ControleAcessoKey = id }).FirstOrDefault();
                return controleAcessos;
            }
        }

        public IEnumerable<ControleAcesso> All()
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcessos = cn.Query<ControleAcesso>("SELECT * FROM COMIS_CONTROLE_ACESSO");
                return controleAcessos;
            }
        }

        public IEnumerable<ControleAcesso> Find(Expression<Func<ControleAcesso, bool>> predicate)
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcessos = cn.GetList<ControleAcesso>(predicate);
                return controleAcessos;
            }
        }

        public ControleAcesso GetFirstLogin()
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcesso = cn.Query<ControleAcesso>("SELECT * FROM COMIS_CONTROLE_ACESSO").FirstOrDefault();
                return controleAcesso;
            }
        }

        public ControleAcesso FindByActiveLogin(string login)
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcesso = cn.Query<ControleAcesso>("SELECT * FROM COMIS_CONTROLE_ACESSO WHERE LOGIN = @Login AND STATUS = @Status ",
                    new { Login = login, Status = "A" }).FirstOrDefault();
                return controleAcesso;
            }
        }

        public ControleAcesso Get_FilhosDiretos(int id)
        {
            using (var cn = ComissoesConnection)
            {
                var controleAcessos = cn.Query<ControleAcesso>("SELECT * FROM COMIS_CONTROLE_ACESSO WHERE COLABORADORKEY_PAI = @ColaboradorKey",
                    new { ColaboradorKey = id }).FirstOrDefault();
                return controleAcessos;
            }
        }
    }
}
