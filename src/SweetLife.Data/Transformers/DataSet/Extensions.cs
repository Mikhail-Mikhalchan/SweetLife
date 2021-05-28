using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace SweetLife.Data
{
    using Transformers.DataSet;

    public static class DataSetExtensionsAsync
    {
        public static async Task<System.Data.DataSet> ToDataSetAsync(this System.Data.Common.DbDataReader reader)
        {
            return await TransformerAsync.TransformAsync(reader).ConfigureAwait(false);
        }
    }
}