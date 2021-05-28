using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SweetLife.Data.Transformers.XmlReader
{
    public static class Transformer
    {
        public static string ReadAsString(System.Xml.XmlReader reader)
        {
            if (reader == null)
            {
                return null;
            }

            var stringBuilder = new StringBuilder();
            while (reader.Read())
            {
                stringBuilder.AppendLine(reader.ReadOuterXml());
            }
            return stringBuilder.ToString();
        }

        public static T Transform<T>(System.Xml.XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(T));
            var model = (T)serializer.Deserialize(reader);
            return model;
        }
        public static T Transform<T>(string xml)
        {
            using (var reader = System.Xml.XmlReader.Create(new StringReader(xml)))
            {
                return Transform<T>(reader);
            }
        }
        public static T TransformFromFile<T>(string filePath)
        {
            using (var reader = System.Xml.XmlReader.Create(File.OpenRead(filePath)))
            {
                return Transform<T>(reader);
            }
        }
    }
    public static class TransformerAsync
    {
        public static async Task<string> ReadAsStringAsync(System.Xml.XmlReader reader)
        {
            if (reader == null)
            {
                return null;
            }

            var stringBuilder = new StringBuilder();
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                stringBuilder.AppendLine(await reader.ReadOuterXmlAsync().ConfigureAwait(false));
            }
            return stringBuilder.ToString();
        }
    }
}
