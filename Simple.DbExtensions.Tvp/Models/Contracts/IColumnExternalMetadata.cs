using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface IColumnExternalMetadata : IColumnInternalMetadata
    {
        /// <inheritdoc cref="DataColumn.AllowDBNull"/>
        bool AllowDBNull
        {
            get;
        }

        /// <inheritdoc cref="DataColumn.MaxLength"/>
        int MaxLength
        {
            get;
        }
    }
}