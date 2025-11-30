using Simple.DbExtensions.Tvp.Metadata;
using Simple.DbExtensions.Tvp.Metadata.Contracts;

using System;
using System.Reflection;

namespace Simple.DbExtensions.Tvp.Storages
{
    internal static class StaticMetadataProvider
    {
        /// <summary>
        /// Gets the underlying type argument 
        /// of the specified nullable or enum 
        /// type.
        /// </summary>
        private static Type GetUnderlyingType(Type closedType)
        {
            Type type = Nullable.GetUnderlyingType(closedType) ?? closedType;

            return type.IsEnum ? Enum.GetUnderlyingType(type) : type;
        }

        /// <summary>
        /// Creates metadata 
        /// based on a class 
        /// definition.
        /// </summary>
        public static IColumnInternalMetadata[] CreateColumns<TRow>() where TRow : class, ITableValued
        {
            PropertyInfo[] properties = TRow.Type.GetProperties();

            ColumnInternalMetadata[] metadata = new
            ColumnInternalMetadata
            [properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                metadata[i] = new ColumnInternalMetadata(properties[i].Name, GetUnderlyingType(properties[i].PropertyType), i);
            }

            return metadata;
        }
    }
}