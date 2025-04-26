using Simple.DbExtensions.Tvp.Models.Contracts;

using Simple.DbExtensions.Tvp.Tests.Abstract;
using Simple.DbExtensions.Tvp.Tests.Models;

using System;

namespace Simple.DbExtensions.Tvp.Tests
{
    public sealed class TypeTests : AbstractTests
    {
        [TestCase(UserData.TABLE_COMMON, nameof(InternalMetadataTableValued.Property0), typeof(int), TestName = $"{ nameof(InternalMetadataTableValued.Property0) } is { nameof(Int32) }", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(UserData.TABLE_COMMON, nameof(InternalMetadataTableValued.Property1), typeof(int), TestName = $"{ nameof(InternalMetadataTableValued.Property1) } is { nameof(Int32) }", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        public void TestNullableType<TRow>(string table, string column, Type type) where TRow : class, ITableValued
        {
            ThatInScope<Type, TRow>(table, (scope) => scope.Table.Columns[column].DataType, Is.EqualTo(type));
        }
    }
}