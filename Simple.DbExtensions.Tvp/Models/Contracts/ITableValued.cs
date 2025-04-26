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
        /// 
        /// </summary>
        static abstract ITableMetadata Table
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        static abstract IColumnInternalMetadata[] Columns
        {
            get;
        }

        /// <inheritdoc cref="DataRow.ItemArray"/>
        RentedBuffer<object> GetRow();
    }
}