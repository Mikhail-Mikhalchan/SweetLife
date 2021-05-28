using System.Data.SqlClient;
using D = SweetLife.Data;

namespace SweetLife.Logic.DataProviders.Mssql
{
    internal class DataProvider: D.DbDataProvider<SqlConnection>, IDataProvider
    {
        public DataProvider(ISettings settings) : base(settings)
        {
        }
    }
}