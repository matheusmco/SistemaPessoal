using System.Data;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;

namespace SistemaPessoal.Data
{
    public abstract class RepositoryBase 
    {
        protected IConfiguration configuration;

        internal IDbConnection Connection
        {
            get
            {
                var conn = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);

                return conn.OpenDbConnection();
            }
        }
    }
}