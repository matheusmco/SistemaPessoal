using System.Data;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;

namespace SistemaPessoal.Data
{
    public abstract class RepositoryBase 
    {
        protected IConfiguration configuration;
        private readonly OrmLiteConnectionFactory _dbFactory;

        internal OrmLiteConnectionFactory Connection
        {
            get
            {
                var conn = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);

                conn.OpenDbConnection();

                return conn;
            }
        }
    }
}