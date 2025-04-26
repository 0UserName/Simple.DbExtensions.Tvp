using Simple.DbExtensions.Tvp.Pools;

using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface ITableValued
    {
        /// <summary>
        /// 
        /// </summary>
        static abstract Type Type
        {
            get;
        }

        /// <summary>
        /// Metadata required to create <see cref="DataTable"/>.
        /// </summary>
        static abstract ITableMetadata Table
        {
            get;
        }

        /// <summary>
        /// Metadata required to create <see cref="DataColumn"/>.
        /// </summary>
        static abstract IColumnInternalMetadata[] Columns
        {
            get;
        }

        /// <summary>
        /// Gets 
        /// an array of values ​​for 
        /// a <see cref="DataRow"/>.
        /// </summary> 
        RentedBuffer<object> GetRow();
    }
}