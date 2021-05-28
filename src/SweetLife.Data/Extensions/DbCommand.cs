using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SweetLife.Data.Extensions
{
    public static class DbCommandExtensions
    {
        public static async Task ExecuteNonQueryAsync(this DbCommand command, DbConnection connection, DbTransaction transaction = null, int? timeout = null)
        {
            command.Connection = connection;
            command.Transaction = transaction;
            if (timeout.HasValue)
            {
                command.CommandTimeout = timeout.Value;
            }

            await connection.EnsureOpenAsync().ConfigureAwait(false);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
        public static async Task<T> ExecuteScalarAsync<T>(this DbCommand command, DbConnection connection, DbTransaction transaction = null, int? timeout = null)
        {
            command.Connection = connection;
            command.Transaction = transaction;
            if (timeout.HasValue)
            {
                command.CommandTimeout = timeout.Value;
            }

            await connection.EnsureOpenAsync().ConfigureAwait(false);
            return (T)await command.ExecuteScalarAsync().ConfigureAwait(false);
        }
        public static async Task<DbDataReader> ExecuteReaderAsync(this DbCommand command, DbConnection connection, DbTransaction transaction = null, int? timeout = null)
        {
            command.Connection = connection;
            command.Transaction = transaction;
            if (timeout.HasValue)
            {
                command.CommandTimeout = timeout.Value;
            }

            await connection.EnsureOpenAsync().ConfigureAwait(false);
            return await command.ExecuteReaderAsync().ConfigureAwait(false);
        }

        public static T SetCommandText<T>(this T command, Type type, string path) where T : DbCommand
        {
            command.CommandText = Helpers.EmbeddedResource.ReadAsString(type, path);
            return command;
        }
        public static T SetCommandText<T>(this T command, string sql) where T : DbCommand
        {
            command.CommandText =  sql;
            return command;
        }
        public static async Task<T> EnsureOpenAsync<T>(this T command) where T : DbCommand
        {
            await command.Connection.EnsureOpenAsync().ConfigureAwait(false);
            return command;
        }
    }
}