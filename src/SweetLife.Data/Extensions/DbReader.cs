using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using SweetLife.Data.Transformers.DbReader;

namespace SweetLife.Data.Extensions
{
    public static class DbReaderExtensionsAsync
    {
        public static async Task<T> FirstOrDefaultAsync<T>(this DbDataReader reader) where T : new()
        {
            return await TransformerAsync.FirstOrDefault<T>(reader).ConfigureAwait(false);
        }

        public static async Task<dynamic> FirstOrDefaultAsync(this DbDataReader reader)
        {
            return await TransformerAsync.FirstOrDefault(reader).ConfigureAwait(false);
        }

        public static async Task<bool> BindAsync(this DbDataReader reader, object instance)
        {
            return await TransformerAsync.BindAsync(reader, instance).ConfigureAwait(false);
        }

        public static async Task<List<T>> ToListAsync<T>(this DbDataReader reader) where T : new()
        {
            return await TransformerAsync.ToListAsync<T>(reader).ConfigureAwait(false);
        }

        public static async Task<List<dynamic>> ToListAsync(this DbDataReader reader)
        {
            return await TransformerAsync.ToListAsync(reader).ConfigureAwait(false);
        }
    }
}