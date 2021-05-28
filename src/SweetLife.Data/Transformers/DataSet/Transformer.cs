using System;
using System.Threading.Tasks;

namespace SweetLife.Data.Transformers.DataSet
{
    public static class TransformerAsync
    {
        public static async Task<System.Data.DataSet> TransformAsync(System.Data.Common.DbDataReader reader)
        {
            var dataSet = await GetDataSetAsync(reader).ConfigureAwait(false);
            return dataSet;
        }

        private static async Task<System.Data.DataSet> GetDataSetAsync(System.Data.Common.DbDataReader reader)
        {
            var dataSet = new System.Data.DataSet();
            dataSet.Clear();
            var i = 0;

            do
            {
                i++;
                var table = await GetDataTableAsync(reader).ConfigureAwait(false);
                table.TableName = "Table" + i;
                if (table.Columns.Count > 0) dataSet.Tables.Add(table);
            } while (await reader.NextResultAsync().ConfigureAwait(false));

            dataSet.AcceptChanges();
            return dataSet;
        }
        private static async Task<System.Data.DataTable> GetDataTableAsync(System.Data.Common.DbDataReader reader)
        {
            var table = new System.Data.DataTable();
            // columns
            for (var i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i) ?? throw new InvalidOperationException());
            }
            // rows
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                var array = new object[table.Columns.Count];
                reader.GetValues(array);
                table.Rows.Add(array);
            }
            return table;
        }
    }
}
