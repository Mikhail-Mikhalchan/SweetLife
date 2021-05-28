using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SweetLife.Data.Extensions;
using SweetLife.Data.Mssql.Extensions;
using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Repositories.Mssql.Employee.List
{
    internal class Repository : IRepository
    {
        private readonly D.IDataProvider _dataProvider;

        public Repository(D.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IList<IEntity>> ExecuteAsync(string searchString = null)
        {
            await using var command = await _dataProvider
                .CreateCommand<SqlCommand>()
                .AppendParameter(nameof(searchString), searchString)
                .SetCommandText(GetType(), "./Query.sql")
                .EnsureOpenAsync().ConfigureAwait(false);

            await using var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            var list = await reader.ToListAsync<Entity>().ConfigureAwait(false);

            return list.Select(item => (IEntity) item).ToList();
        }
    }
}