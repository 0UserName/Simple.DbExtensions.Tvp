using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Metadata.Contracts
{
    public interface IColumnInternalMetadata
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Type of data stored in the column.
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// Position of the column.
        /// </summary>
        int Ordinal
        {
            get;
        }

        DataColumn CreateColumn();
    }
}