using System.Data.SqlClient;
using System.Threading.Tasks;
using SweetLife.Data.Extensions;
using SweetLife.Data.Mssql.Extensions;

using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Repositories.Mssql.Employee.SaveNotification
{
    internal class Repository : IRepository
    {
        private readonly D.IDataProvider _dataProvider;

        public Repository(D.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<bool> ExecuteAsync(Input input)
        {
            await using var command = await _dataProvider
                .CreateCommand<SqlCommand>()
                .SetCommandText(GetType(), "./Query.sql")
                .AppendParameter(nameof(input.EmployeeId), input.EmployeeId)
                .AppendParameter(nameof(input.ContentType), input.ContentType)
                .AppendStreamParameter(nameof(input.Content), input.Content)
                .EnsureOpenAsync().ConfigureAwait(false);

            await using var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            return await reader.FirstOrDefaultAsync<bool>().ConfigureAwait(false);
        }
    }
}