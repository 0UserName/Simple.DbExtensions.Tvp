using Simple.DbExtensions.Tvp.Models.Contracts;

using System.Collections.Concurrent;

namespace Simple.DbExtensions.Tvp.Storages
{
    public static class MetadataStorage
    {
        private static readonly
            ConcurrentDictionary<string, IColumnExternalMetadata[]> _storage = new
            ConcurrentDictionary<string, IColumnExternalMetadata[]>
            ();

        /// <summary>
        /// 
        /// </summary>
        public static void AddColumns(string type, IColumnExternalMetadata[] metadata)
        {
            _storage[type] = metadata;
        }

        /// <summary>
        /// 
        /// </summary>
        internal static IColumnInternalMetadata[] GetColumns<TRow>() where TRow : ITableValued
        {
            return _storage.TryGetValue(TRow.Table.Name, out IColumnExternalMetadata[] metadata) ? metadata : StaticMetadataProvider.GetColumns<TRow>();
        }
    }
}