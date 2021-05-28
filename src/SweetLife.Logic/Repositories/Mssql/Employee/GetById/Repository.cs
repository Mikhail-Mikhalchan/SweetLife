using System.Data.SqlClient;
using System.Threading.Tasks;
using SweetLife.Data.Extensions;
using SweetLife.Data.Mssql.Extensions;

using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Repositories.Mssql.Employee.GetById
{
    internal class Repository : IRepository
    {
        private readonly D.IDataProvider _dataProvider;

        public Repository(D.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEntity> ExecuteAsync(long id)
        {
            await using var command = await _dataProvider
                .CreateCommand<SqlCommand>()
                .SetCommandText(GetType(), "./Query.sql")
                .AppendParameter(nameof(id), id)
                .EnsureOpenAsync().ConfigureAwait(false);

            await using var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            return await reader.FirstOrDefaultAsync<Entity>().ConfigureAwait(false);
        }
    }
}