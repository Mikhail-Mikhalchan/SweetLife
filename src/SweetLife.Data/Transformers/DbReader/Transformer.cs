using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Reflection;
using System.Threading.Tasks;
using SweetLife.Data.Helpers;

namespace SweetLife.Data.Transformers.DbReader
{
    internal static class TransformerAsync
    {
        // одна строка<T>
        public static async Task<T> FirstOrDefault<T>(DbDataReader reader) where T : new()
        {
            if (! await reader.ReadAsync().ConfigureAwait(false))
            {
                return default(T);
            }
            var reflectionInfo = RecordTransformer.GetReflectionInfo(reader, typeof(T).GetTypeInfo());

            return RecordTransformer.ToObject<T>(reader, reflectionInfo);
        }

        // одна строка<dynamic>
        public static async Task<dynamic> FirstOrDefault(DbDataReader reader)
        {
            if (! await reader.ReadAsync().ConfigureAwait(false))
            {
                return null;
            }

            return RecordTransformer.ToDynamic(reader);
        }

        // одна строка на существующий instance
        public static async Task<bool> BindAsync(DbDataReader reader, object instance)
        {
            if (!await reader.ReadAsync().ConfigureAwait(false))
            {
                return false;
            }

            var reflectionInfo = RecordTransformer.GetReflectionInfo(reader, instance.GetType().GetTypeInfo());
            RecordTransformer.Bind(reader, instance, reflectionInfo);

            return true;
        }

        // IList<T>
        public static async Task<List<T>> ToListAsync<T>(DbDataReader reader) where T : new()
        {
            var list = new List<T>();
            var reflectionInfo = RecordTransformer.GetReflectionInfo(reader, typeof(T).GetTypeInfo());

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(RecordTransformer.ToObject<T>(reader, reflectionInfo));
            }

            return list;
        }

        // IList<dynamic>
        public static async Task<List<dynamic>> ToListAsync(DbDataReader reader)
        {
            var list = new List<dynamic>();

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(RecordTransformer.ToDynamic(reader));
            }

            return list;
        }
    }

    internal static class RecordTransformer
    {
        // Bind
        public static void Bind(System.Data.IDataRecord reader, object instance, ReflectionInfo[] reflectionInfo)
        {
            var values = new object[reader.FieldCount];
            reader.GetValues(values);

            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.IsDBNull(i)) continue;

                reflectionInfo[i].SetValue(instance, values[i]);
            }
        }

        // ToObject<T>
        public static T ToObject<T>(System.Data.IDataRecord reader, ReflectionInfo[] reflectionInfo) where T : new()
        {
            var instance = new T();
            Bind(reader, instance, reflectionInfo);
            return instance;
        }

        // ToDynamic
        public static dynamic ToDynamic(System.Data.IDataRecord reader)
        {
            var instance = new ExpandoObject() as IDictionary<string, object>;
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                instance.Add(reader.GetName(i), value);
            }
            return instance;
        }

        // GetReflectionInfo
        public static ReflectionInfo[] GetReflectionInfo(System.Data.IDataRecord reader, TypeInfo typeInfo)
        {
            var result = new ReflectionInfo[reader.FieldCount];
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var fieldName = reader.GetName(i);

                var reflectionInfo = new ReflectionInfo
                {
                    PropertyInfo = ReflectionHelper.GetPropertyInfo(typeInfo, fieldName)
                };

                if (reflectionInfo.PropertyInfo == null)
                {
                    reflectionInfo.FieldInfo = ReflectionHelper.GetFieldInfo(typeInfo, fieldName);
                }

                result[i] = reflectionInfo;
            }
            return result;
        }
    }

    internal class ReflectionInfo
    {
        public PropertyInfo PropertyInfo { get; set; }
        public FieldInfo FieldInfo { get; set; }

        public bool SetValue(object instance, object value)
        {
            if (PropertyInfo != null)
            {
                PropertyInfo.SetValue(instance, value, null);
                return true;
            }
            if (FieldInfo != null)
            {
                FieldInfo.SetValue(instance, value);
                return false;
            }

            return false;
        }
    }
}
