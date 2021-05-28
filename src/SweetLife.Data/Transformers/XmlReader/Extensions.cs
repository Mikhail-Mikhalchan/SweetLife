using System.Threading.Tasks;
using System.Xml;

// ReSharper disable once CheckNamespace
namespace SweetLife.Data
{
    using Transformers.XmlReader;

    public static class XmlExtensions
    {
        public static T Parse<T>(this XmlReader reader)
        {
            return Transformer.Transform<T>(reader);
        }
        public static string ReadAsString(this XmlReader reader)
        {
            return Transformer.ReadAsString(reader);
        }
    }
    public static class XmlExtensionsAsync
    {
        public static async Task<string> ReadAsStringAsync(this XmlReader reader)
        {
            return await TransformerAsync.ReadAsStringAsync(reader).ConfigureAwait(false);
        }
    }
}