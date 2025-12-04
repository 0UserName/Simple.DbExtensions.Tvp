using NUnit.Framework.Constraints;

using Simple.DbExtensions.Tvp.Metadata;
using Simple.DbExtensions.Tvp.Metadata.Contracts;

using Simple.DbExtensions.Tvp.Parameters;
using Simple.DbExtensions.Tvp.Storages;

using Simple.DbExtensions.Tvp.Tests.Models;

using System;
using System.Data;

using System.IO;
using System.Text.Json;

namespace Simple.DbExtensions.Tvp.Tests.Abstracts
{
    public abstract class AbstractTests
    {
        protected static class TestData
        {
            public const string TABLE_COMMON = "Common";
            public const string TABLE_UNIQUE = "Unique";
        }

        private static TParameter CreateParameter<TRow, TParameter>(string table) where TRow : class, ITableValued where TParameter : class
        {
            return JsonSerializer.Deserialize<TRow[]>(File.ReadAllText(Path.Combine("TestData", table) + ".json")).Build(typeof(TParameter) == typeof(DataTable)) as TParameter;
        }

        /// <inheritdoc cref="Assert.That{TActual}(ActualValueDelegate{TActual}, IResolveConstraint, NUnitString, string, string)"/>
        protected static void That<TActual, TRow, TParameter>(string table, Func<TParameter, TActual> action, IResolveConstraint expression) where TRow : class, ITableValued where TParameter : class
        {
            Assert.That(action(CreateParameter<TRow, TParameter>(table)), expression);
        }

        /// <summary>
        /// Method that is called 
        /// once to perform setup 
        /// before any child tests are run.
        /// </summary>
        [OneTimeSetUp]
        public virtual void Init()
        {
            MetadataStorage.AddColumns(nameof(ExternalMetadataTableValued), new IColumnInternalMetadata[]
            {
                new ColumnExternalMetadata(string.Empty, nameof(ExternalMetadataTableValued.Property0), typeof(int), 3, true   , -1, default),
                new ColumnExternalMetadata(string.Empty, nameof(ExternalMetadataTableValued.Property1), typeof(int), 2, true   , -1, default),
                new ColumnExternalMetadata(string.Empty, nameof(ExternalMetadataTableValued.Property2), typeof(int), 1, default, -1, true),
                new ColumnExternalMetadata(string.Empty, nameof(ExternalMetadataTableValued.Property3), typeof(int), 0, default, -1, true)
            });
        }
    }
}