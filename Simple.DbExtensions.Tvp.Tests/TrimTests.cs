using Simple.DbExtensions.Tvp.Metadata.Contracts;

using Simple.DbExtensions.Tvp.Tests.Abstracts;
using Simple.DbExtensions.Tvp.Tests.Models;

using System.Data;

namespace Simple.DbExtensions.Tvp.Tests
{
    public sealed class TrimTests : AbstractTests
    {
        [TestCase(TestData.TABLE_COMMON, nameof(ExternalMetadataTableValued.Property4), TestName = $"{ nameof(ExternalMetadataTableValued.Property4) } is discarded", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        [TestCase(TestData.TABLE_COMMON, nameof(ExternalMetadataTableValued.Property5), TestName = $"{ nameof(ExternalMetadataTableValued.Property5) } is discarded", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        public void TestTrimColumn<TRow>(string table, string column) where TRow : class, ITableValued
        {
            That<bool, TRow, DataTable>(table, (p) => p.Columns.Contains(column), Is.False);
        }
    }
}