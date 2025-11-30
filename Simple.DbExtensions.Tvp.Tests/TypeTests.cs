using Simple.DbExtensions.Tvp.Metadata.Contracts;

using Simple.DbExtensions.Tvp.Tests.Abstracts;
using Simple.DbExtensions.Tvp.Tests.Models;

using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Tests
{
    public sealed class TypeTests : AbstractTests
    {
        [TestCase(TestData.TABLE_COMMON, nameof(InternalMetadataTableValued.Property0), typeof(int), TestName = $"{ nameof(InternalMetadataTableValued.Property0) } is { nameof(Int32) }", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        [TestCase(TestData.TABLE_COMMON, nameof(InternalMetadataTableValued.Property1), typeof(int), TestName = $"{ nameof(InternalMetadataTableValued.Property1) } is { nameof(Int32) }", TypeArgs = new[] { typeof(InternalMetadataTableValued) })]
        public void TestNullableType<TRow>(string table, string column, Type type) where TRow : class, ITableValued
        {
            That<Type, TRow, DataTable>(table, (p) => p.Columns[column].DataType, Is.EqualTo(type));
        }
    }
}