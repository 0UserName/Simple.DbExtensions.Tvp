using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Models;
using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Reflection;

namespace Simple.DbExtensions.Tvp.Storages
{
    internal static class StaticMetadataProvider
    {
        /// <summary>
        /// Creates metadata based on class layout.
        /// </summary>
        public static IColumnInternalMetadata[] CreateColumns<TRow>() where TRow : class, ITableValued
        {
            PropertyInfo[] properties = TRow.Type.GetProperties();

            ColumnInternalMetadata[] metadata = new
            ColumnInternalMetadata
            [properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                metadata[i] = new ColumnInternalMetadata(properties[i].Name, (Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType).FullName, properties[i].GetCustomAttribute<OrdinalAttribute>()?.Ordinal ?? i);
            }

            return metadata;
        }
    }
}