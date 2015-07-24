using System;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace Dufry.Comissoes.Data.Repository.Dapper.Common
{
    public class Repository : IDisposable
    {

        public IDbConnection ComissoesConnection
        {
            get { return new SqlConnection(ConfigurationManager.ConnectionStrings["Dufry.ComissoesEntities_BI"].ConnectionString); }
        }

        public IDbConnection BIVendasConnection
        {
            get { return new SqlConnection(ConfigurationManager.ConnectionStrings["Dufry.Vendas_DMEntities_BI"].ConnectionString); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
