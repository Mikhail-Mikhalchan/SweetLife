using System.Data.SqlClient;
using System.Threading.Tasks;
using SweetLife.Data.Extensions;
using SweetLife.Data.Mssql.Extensions;

using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Repositories.Mssql.Employee.Update
{
    internal class Repository : IRepository
    {
        private readonly D.IDataProvider _dataProvider;

        public Repository(D.IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<int> ExecuteAsync(IEntity entity)
        {
            await using var command = await _dataProvider
                .CreateCommand<SqlCommand>()
                .SetCommandText(GetType(), "./Query.sql")
                .AppendParameter(nameof(entity.Id), entity.Id)
                .AppendParameter(nameof(entity.LastName), entity.LastName)
                .AppendParameter(nameof(entity.FirstName), entity.FirstName)
                .AppendParameter(nameof(entity.Patronymic), entity.Patronymic)
                .AppendParameter(nameof(entity.Gender), entity.Gender)
                .AppendParameter(nameof(entity.BirthDate), entity.BirthDate)
                .AppendParameter(nameof(entity.PassportNumber), entity.PassportNumber)
                .AppendParameter(nameof(entity.PassportSeries), entity.PassportSeries)
                .AppendParameter(nameof(entity.PassportRegistrationAddress), entity.PassportRegistrationAddress)
                .AppendParameter(nameof(entity.PassportReleaseDate), entity.PassportReleaseDate)
                .AppendParameter(nameof(entity.MigrationCardNumber), entity.MigrationCardNumber)
                .AppendParameter(nameof(entity.MigrationCardSeries), entity.MigrationCardSeries)
                .AppendParameter(nameof(entity.PatentNumber), entity.PatentNumber)
                .AppendParameter(nameof(entity.PatentSeries), entity.PatentSeries)
                .AppendParameter(nameof(entity.TemporaryRegistrationAddress), entity.TemporaryRegistrationAddress)
                .AppendParameter(nameof(entity.IsFired), entity.IsFired)
                .AppendParameter(nameof(entity.NotificationFileId), entity.NotificationFileId)
                .AppendParameter(nameof(entity.LastTaxReceiptFileId), entity.LastTaxReceiptFileId)
                .EnsureOpenAsync().ConfigureAwait(false);

            await using var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
            return await reader.FirstOrDefaultAsync<int>().ConfigureAwait(false);
        }
    }
}