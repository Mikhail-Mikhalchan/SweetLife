using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SweetLife.Data.Mssql.Extensions
{
    public static class SqlCommandExtensions
    {
        public static SqlCommand AppendParameter(this SqlCommand command, string name, object value)
        {
            var input = value ?? DBNull.Value;
            command.Parameters.AddWithValue("@" + name, input);
            return command;
        }
        public static SqlCommand AppendParameter(this SqlCommand command, string name, object value, SqlDbType type)
        {
            var input = value ?? DBNull.Value;
            var parameter = command.Parameters.AddWithValue("@" + name, input);
            parameter.SqlDbType = type;
            return command;
        }
        public static SqlCommand AppendStreamParameter(this SqlCommand command, string name, Stream stream)
        {
            var input = (object)stream ?? DBNull.Value;
            command.Parameters.Add("@" + name, SqlDbType.Binary, -1).Value = input;
            return command;
        }
    }
}