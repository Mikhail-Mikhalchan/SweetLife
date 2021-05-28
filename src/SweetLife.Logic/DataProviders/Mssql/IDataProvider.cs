using System.Data.SqlClient;
using D = SweetLife.Data;

namespace SweetLife.Logic.DataProviders.Mssql
{
    public interface IDataProvider: D.IDbDataProvider<SqlConnection>
    {
        
    }
}