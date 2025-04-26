using NUnit.Framework.Constraints;

using Simple.DbExtensions.Tvp.Models.Contracts;
using Simple.DbExtensions.Tvp.Models.Table;

using Simple.DbExtensions.Tvp.Storages;

using Simple.DbExtensions.Tvp.Tests.Models;

using System;

namespace Simple.DbExtensions.Tvp.Tests.Abstract
{
    public abstract class AbstractTests
    {
        protected static class UserData
        {
            public const string TABLE_COMMON = "Common";
            public const string TABLE_LENGTH = "Length";
            public const string TABLE_UNIQUE = "Unique";
        }

        /// <inheritdoc cref="Assert.That{TActual}(ActualValueDelegate{TActual}, IResolveConstraint, NUnitString, string, string)"/>
        protected static void ThatInScope<TActual, TRow>(string table, Func<PooledDataTableScope<TRow>, TActual> action, IResolveConstraint expression) where TRow : class, ITableValued
        {
            using (PooledDataTableScope<TRow> scope = Utils.CreateRowsAndScope<TRow>(table))
            {
                Assert.That(action(scope), expression);
            }
        }

        /// <summary>
        /// Method that is called 
        /// once to perform setup 
        /// before any child tests are run.
        /// </summary>
        [OneTimeSetUp]
        public virtual void Init()
        {
            MetadataStorage.AddColumns(nameof(ExternalMetadataTableValued), Utils.CreateColumns(nameof(ExternalMetadataTableValued)));
        }
    }
}