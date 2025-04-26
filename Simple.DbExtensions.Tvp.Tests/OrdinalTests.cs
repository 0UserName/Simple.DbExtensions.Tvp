using Simple.DbExtensions.Tvp.Models.Contracts;

using Simple.DbExtensions.Tvp.Tests.Abstract;
using Simple.DbExtensions.Tvp.Tests.Models;

namespace Simple.DbExtensions.Tvp.Tests
{
    public sealed class OrdinalTests : AbstractTests
    {
        /// <remarks>
        /// L - layout / A - attribute / M - metadata
        /// </remarks>
        [TestCase(UserData.TABLE_COMMON, 0, nameof(InternalMetadataTableValued.Property0), TestName = $"{ nameof(InternalMetadataTableValued.Property0) } is specified by L [0]", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 1, nameof(InternalMetadataTableValued.Property1), TestName = $"{ nameof(InternalMetadataTableValued.Property1) } is specified by L [1]", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 2, nameof(InternalMetadataTableValued.Property3), TestName = $"{ nameof(InternalMetadataTableValued.Property3) } is specified by A [2]", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 3, nameof(InternalMetadataTableValued.Property2), TestName = $"{ nameof(InternalMetadataTableValued.Property2) } is specified by A [3]", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 0, nameof(ExternalMetadataTableValued.Property3), TestName = $"{ nameof(ExternalMetadataTableValued.Property3) } is specified by M [0]", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 1, nameof(ExternalMetadataTableValued.Property2), TestName = $"{ nameof(ExternalMetadataTableValued.Property2) } is specified by M [1]", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 2, nameof(ExternalMetadataTableValued.Property1), TestName = $"{ nameof(ExternalMetadataTableValued.Property1) } is specified by M [2]", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, 3, nameof(ExternalMetadataTableValued.Property0), TestName = $"{ nameof(ExternalMetadataTableValued.Property0) } is specified by M [3]", TypeArgs = new[] { typeof(ExternalMetadataTableValued) })]
        public void TestOrdinal<TRow>(string table, int ordinal, string column) where TRow : class, ITableValued
        {
            ThatInScope<string, TRow>(table, (scope) => scope.Table.Columns[ordinal].ColumnName, Is.EqualTo(column));
        }
    }
}