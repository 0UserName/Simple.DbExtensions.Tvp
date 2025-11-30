using Simple.DbExtensions.Tvp.Metadata.Contracts;

using System.Collections.Concurrent;

namespace Simple.DbExtensions.Tvp.Storages
{
    public static class MetadataStorage
    {
        private static readonly
            ConcurrentDictionary<string, IColumnInternalMetadata[]> _storage = new
            ConcurrentDictionary<string, IColumnInternalMetadata[]>
            ();

        public static void AddColumns(string type, IColumnInternalMetadata[] metadata)
        {
            _storage[type] = metadata;
        }

        public static IColumnInternalMetadata[] GetColumns<TRow>() where TRow : class, ITableValued
        {
            return _storage.TryRemove(TRow.Table.Name, out IColumnInternalMetadata[] metadata) ? metadata : StaticMetadataProvider.CreateColumns<TRow>();
        }
    }
}