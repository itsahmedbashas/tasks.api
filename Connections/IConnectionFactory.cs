using System.Data;

namespace Tasks.API.Connections
{
    public interface IConnFactory
    {
        public IDbConnection GetSqlConnection();
    }
}