using Simple.DbExtensions.Tvp.Metadata.Abstracts;
using Simple.DbExtensions.Tvp.Metadata.Contracts;

namespace Simple.DbExtensions.Tvp.Tests.Models.Abstracts
{
    public abstract class AbstractMetadataTableValued<TRow> : AbstractTableValued<TRow> where TRow : class, ITableValued
    {
        public int? Property0
        {
            get;
            set;
        }

        public int? Property1
        {
            get;
            set;
        }

        public int Property2
        {
            get;
            set;
        }

        public int Property3
        {
            get;
            set;
        }
    }
}