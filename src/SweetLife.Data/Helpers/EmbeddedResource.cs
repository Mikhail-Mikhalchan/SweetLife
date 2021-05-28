using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SweetLife.Data.Helpers
{
    public static class EmbeddedResource
    {
        public static Stream ReadAsStream(Type type, string path)
        {
            var assembly = type.GetTypeInfo().Assembly;
            var embeddedResourcePath = EmbeddedResourcePath(type, path);
            var stream = assembly.GetManifestResourceStream(embeddedResourcePath);
            if (stream == null)
            {
                throw new Exception($"Embedded resource '{embeddedResourcePath}' was not found.");
            }
            return stream;
        }

        public static string ReadAsString(Type type, string path)
        {
            using (var reader = new StreamReader(ReadAsStream(type, path)))
            {
                return reader.ReadToEnd();
            }
        }
        public static async Task<string> ReadAsStringAsync(Type type, string path)
        {
            using (var reader = new StreamReader(ReadAsStream(type, path)))
            {
                return await reader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public static byte[] ReadAsBytes(Type type, string path)
        {
            using (var stream = ReadAsStream(type, path))
            {
                var count = (int)stream.Length;
                var data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
        public static async Task<byte[]> ReadAsBytesAsync(Type type, string path)
        {
            using (var stream = ReadAsStream(type, path))
            {
                var count = (int)stream.Length;
                var data = new byte[count];
                await stream.ReadAsync(data, 0, count).ConfigureAwait(false);
                return data;
            }
        }

        private static string EmbeddedResourcePath(Type type, string path)
        {
            if (path.StartsWith("./") || path.StartsWith(".\\"))
            {
                path = type.Namespace + "." + path.Substring(2);
            }

            return path.Replace("\\", ".").Replace("/", ".");
        }
    }
}
