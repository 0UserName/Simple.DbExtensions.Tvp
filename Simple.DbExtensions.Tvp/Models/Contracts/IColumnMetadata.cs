using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface IColumnMetadata
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// The type of 
        /// data stored 
        /// in the
        /// column.
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// Creates a column using metadata.
        /// </summary>
        DataColumn CreateColumn();
    }
}