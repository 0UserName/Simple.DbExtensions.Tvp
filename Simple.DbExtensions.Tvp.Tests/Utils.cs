using Simple.DbExtensions.Tvp.Models;
using Simple.DbExtensions.Tvp.Models.Contracts;
using Simple.DbExtensions.Tvp.Models.Table;

using System.IO;
using System.Text.Json;

namespace Simple.DbExtensions.Tvp.Tests
{
    internal static class Utils
    {
        private static class Constants
        {
            public const string TYPE_METADATA = "Metadata";
            public const string TYPE_USERDATA = "UserData";
        }

        private static readonly JsonSerializerOptions _options = new
                                JsonSerializerOptions
        {
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        /// <inheritdoc cref="JsonSerializer.Deserialize{TValue}(string, JsonSerializerOptions?)"/>
        private static T Deserialize<T>(string type, string table)
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine("Data", type, table) + ".json"), _options);
        }

        /// <summary>
        /// Creates metadata based on user-defined 
        /// specifications provided in JSON format.
        /// </summary>
        public static IColumnExternalMetadata[] CreateColumns(string table)
        {
            return Deserialize<ColumnExternalMetadata[]>(Constants.TYPE_METADATA, table);
        }

        /// <summary>
        /// 
        /// </summary>
        public static PooledDataTableScope<TRow> CreateRowsAndScope<TRow>(string table) where TRow : class, ITableValued
        {
            return Deserialize<TRow[]>(Constants.TYPE_USERDATA, table).BuildScope();
        }
    }
}