using SweetLife.Data.Extensions;
using System;
using System.Data.Common;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace SweetLife.Data
{
    public interface IDbDataProvider : IDisposable
    {
    }

    public interface IDbDataProvider<out TConnection> : IDbDataProvider
        where TConnection : DbConnection, new()
    {
        TConnection Connection { get; }

        Task BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();

        DbCommand CreateCommand();
        T CreateCommand<T>() where T : DbCommand;
        
        Task ExecuteNonQueryAsync(Type type, string path);
        Task<T> ExecuteScalarAsync<T>(Type type, string path);
    }

    public abstract class DbDataProvider<TConnection> : IDbDataProvider<TConnection>
        where TConnection : DbConnection, new()
    {
        public TConnection Connection { get; }
        protected DbTransaction Transaction { get; set; }
        protected int TransactionCount { get; set; }

        protected DbDataProvider(ISettings settings)
        {
            Connection = new TConnection { ConnectionString = settings.ConnectionString };
        }
        public void Dispose()
        {
            try
            {
                Transaction?.Dispose();
                Connection?.Close();
                Transaction = null;
            }
            catch
            {
                // ignored
            }
        }

        public async Task BeginTransactionAsync()//System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.Unspecified)
        {
            //if (Transaction != null)
            //{
            //    return;
            //}

            if (TransactionCount == 0)
            {
                await Connection.EnsureOpenAsync().ConfigureAwait(false);
                //Transaction = await Task.Run(() => Connection.BeginTransaction()); // https://docs.microsoft.com/ru-ru/dotnet/framework/data/adonet/asynchronous-programming
                Transaction = Connection.BeginTransaction();
            }
            TransactionCount++;
        }
        public void CommitTransaction()
        {
            if (Transaction == null)
            {
                return;
            }

            if (TransactionCount > 1)
            {
                TransactionCount--;
                return;
            }

            //await Task.Run(() => Transaction.Commit()).ConfigureAwait(false);
            Transaction.Commit();
            //await Task.CompletedTask.ConfigureAwait(false).ConfigureAwait(false);
            //Transaction = null;
        }
        public void RollbackTransaction()
        {
            //if (Transaction == null)
            //{
            //    return;
            //}

            //await Task.Run(() => Transaction.Rollback()).ConfigureAwait(false);
            Transaction?.Rollback();
            //await Task.CompletedTask.ConfigureAwait(false);
            TransactionCount = 0;
            //Transaction = null;
        }

        public DbCommand CreateCommand()
        {
            var command = Connection.CreateCommand();
            command.Connection = Connection;
            command.Transaction = Transaction;
            return command;
        }
        public T CreateCommand<T>() where T : DbCommand
        {
            return (T)CreateCommand();
        }

        public async Task ExecuteNonQueryAsync(Type type, string path)
        {
            var command = await CreateCommand()
                .SetCommandText(type, path)
                .EnsureOpenAsync().ConfigureAwait(false);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
        public async Task<T> ExecuteScalarAsync<T>(Type type, string path)
        {
            var command = await CreateCommand()
                .SetCommandText(type, path)
                .EnsureOpenAsync().ConfigureAwait(false);
            return (T)await command.ExecuteScalarAsync().ConfigureAwait(false);
        }
    }
}