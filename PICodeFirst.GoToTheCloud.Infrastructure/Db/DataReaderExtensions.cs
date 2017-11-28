using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.Db
{
    public static class DataReaderExtensions
    {
        public static Guid GetGuidOrDefault(this IDataReader reader, string fieldName)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? Guid.Empty : reader.GetGuid(columnNumber);
        }

        public static string GetStringOrDefault(this IDataReader reader, string fieldName)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? string.Empty : reader.GetString(columnNumber);
        }

        public static DateTime GetDateTimeOrDefault(this IDataReader reader, string fieldName)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? DateTime.MinValue : reader.GetDateTime(columnNumber);
        }

        public static int GetIntOrDefault(this IDataReader reader, string fieldName, int defaultValue = 0)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? defaultValue : reader.GetInt32(columnNumber);
        }

        public static Int32 GetInt32OrDefault(this IDataReader reader, string fieldName)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? Int32.MinValue : reader.GetInt32(columnNumber);
        }

        public static bool GetBoolOrDefault(this IDataReader reader, string fieldName, bool defaultValue = false)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? defaultValue : reader.GetBoolean(columnNumber);
        }

        public static float GetFloatOrDefault(this IDataReader reader, string fieldName, float defaultValue = 0)
        {
            int columnNumber = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(columnNumber) ? defaultValue : reader.GetFloat(columnNumber);
        }

        public static double GetDoubleOrDefault(this IDataReader reader, string fieldName, double defaultValue = 0)
        {
            int columnNumber = reader.GetOrdinal(fieldName);

            return reader.IsDBNull(columnNumber) ? defaultValue : reader.GetDouble(columnNumber);
        }
    }
}
