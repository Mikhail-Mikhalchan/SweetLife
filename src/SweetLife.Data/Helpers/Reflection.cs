using System.Reflection;

namespace SweetLife.Data.Helpers
{
    internal static class ReflectionHelper
    {
        public static FieldInfo GetFieldInfo(TypeInfo typeInfo, string name)
        {
            if (typeInfo == null)
                return null;

            return typeInfo.GetDeclaredField(name) ?? GetFieldInfo(typeInfo.BaseType?.GetTypeInfo(), name);
        }

        public static PropertyInfo GetPropertyInfo(TypeInfo typeInfo, string name)
        {
            if (typeInfo == null)
                return null;

            return typeInfo.GetDeclaredProperty(name) ?? GetPropertyInfo(typeInfo.BaseType?.GetTypeInfo(), name);
        }
    }
}