using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SweetLife.Data.Extensions
{
    public static class DbConnectionExtensions
    {
        public static async Task EnsureOpenAsync(this DbConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync().ConfigureAwait(false);
            }
        }

        public static async Task ExecuteNonQueryAsync(this DbConnection connection, Type type, string path, DbTransaction transaction, int? timeout = null)
        {
            var sql = await Helpers.EmbeddedResource.ReadAsStringAsync(type, path).ConfigureAwait(false);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                await command.ExecuteNonQueryAsync(connection, transaction, timeout).ConfigureAwait(false);
            }
        }

        public static async Task<T> ExecuteScalarAsync<T>(this DbConnection connection, Type type, string path, DbTransaction transaction, int? timeout = null)
        {
            var sql = await Helpers.EmbeddedResource.ReadAsStringAsync(type, path).ConfigureAwait(false);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                return await command.ExecuteScalarAsync<T>(connection, transaction, timeout).ConfigureAwait(false);
            }
        }
        public static async Task<T> ExecuteFirstOrDefaultAsync<T>(this DbConnection connection, Type type, string path, DbTransaction transaction, int? timeout = null) where T : new()
        {
            var sql = await Helpers.EmbeddedResource.ReadAsStringAsync(type, path).ConfigureAwait(false);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Transaction = transaction;
                using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    return await reader.FirstOrDefaultAsync<T>().ConfigureAwait(false);
                }
            }
        }
    }
}