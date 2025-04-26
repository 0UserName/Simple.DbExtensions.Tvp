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
        public static IColumnInternalMetadata[] GetColumns<TRow>() where TRow : class, ITableValued
        {
            return _storage.TryRemove(TRow.Table.Name, out IColumnExternalMetadata[] metadata) ? metadata : StaticMetadataProvider.CreateColumns<TRow>();
        }
    }
}