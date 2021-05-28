using System.Data.SqlClient;
using System.Threading.Tasks;
using SweetLife.Data.Extensions;
using SweetLife.Data.Mssql.Extensions;

using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Repositories.Mssql.File.GetById
{
    internal class Repository : IRepository
    {
        private readonly D.IDataProvider _dataProvider;

        public Repository(D.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Result> ExecuteAsync(long id)
        {
            await using var command = await _dataProvider.CreateCommand<SqlCommand>()
                .SetCommandText(GetType(), "./Query.sql")
                .AppendParameter(nameof(id), id)
                .EnsureOpenAsync().ConfigureAwait(false);

            var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            if (await reader.ReadAsync().ConfigureAwait(false))
            {
                return new Result
                {
                    ContentType = reader.GetString(reader.GetOrdinal("ContentType")),
                    Content = reader.GetStream(reader.GetOrdinal("Content")),
                    Reader = reader
                };
            }

            return new Result();
        }
    }
}
