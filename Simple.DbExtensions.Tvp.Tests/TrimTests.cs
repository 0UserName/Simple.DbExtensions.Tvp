using Simple.DbExtensions.Tvp.Models.Contracts;

using Simple.DbExtensions.Tvp.Tests.Abstract;
using Simple.DbExtensions.Tvp.Tests.Models;

namespace Simple.DbExtensions.Tvp.Tests
{
    public sealed class TrimTest : AbstractTests
    {
        [TestCase(UserData.TABLE_COMMON, nameof(ExternalMetadataTableValued.Property4), TestName = $"{ nameof(ExternalMetadataTableValued.Property4) } is discarded", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, nameof(ExternalMetadataTableValued.Property5), TestName = $"{ nameof(ExternalMetadataTableValued.Property5) } is discarded", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        public void TestTrimColumn<TRow>(string table, string column) where TRow : class, ITableValued
        {
            ThatInScope<bool, TRow>(table, (scope) => scope.Table.Columns.Contains(column), Is.False);
        }
    }
}