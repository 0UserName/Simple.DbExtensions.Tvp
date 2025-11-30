using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Metadata.Contracts;
using Simple.DbExtensions.Tvp.Parameters.Contracts;

using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Data.Common;

using System.Runtime.InteropServices;

namespace Simple.DbExtensions.Tvp.Parameters
{
    internal sealed class ParameterDataDR<TRow>(ObjectPool<ParameterDataDR<TRow>> pool) : DbDataReader, IParameter<TRow> where TRow : class, ITableValued
    {
        private IEnumerator<TRow> _enumerator;

        /// <inheritdoc/>
        public override object this[int ordinal]
        {
            get => GetValue(ordinal);
        }

        /// <inheritdoc/>
        public override object this[string name]
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int Depth
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int FieldCount
        {
            get => TRow.Columns.Length;
        }

        /// <inheritdoc/>
        public override bool HasRows
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool IsClosed
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int RecordsAffected
        {
            get => throw new NotImplementedException();
        }

        private static ReadOnlySpan<T> AsSpan<T>(object value) where T : struct
        {
            switch (value)
            {
                case string v: return MemoryMarshal.Cast<char, T>(v.AsSpan());
                case char[] v: return MemoryMarshal.Cast<char, T>(v.AsSpan());
                case byte[] v: return MemoryMarshal.Cast<byte, T>(v.AsSpan());

                default: throw new InvalidCastException($"{ typeof(T).FullName } is not supported");
            }
        }

        private static long CopyToBuffer<T>(ReadOnlySpan<T> value, long dataOffset, Span<T> buffer, int bufferOffset, int length)
        {
            int copy = 0;

            if (value.Length > dataOffset)
            {
                copy = Math.Min(length, value.Length - (int)dataOffset);

                value.Slice((int)dataOffset, copy).CopyTo(buffer.Slice(bufferOffset, copy));
            }

            return copy;
        }

        /// <inheritdoc/>
        public override bool GetBoolean(int ordinal)
        {
            return _enumerator.Current.GetValue<bool>(ordinal);
        }

        /// <inheritdoc/>
        public override byte GetByte(int ordinal)
        {
            return _enumerator.Current.GetValue<byte>(ordinal);
        }

        /// <inheritdoc/>
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return CopyToBuffer(AsSpan<byte>(GetValue(ordinal)), dataOffset, buffer, bufferOffset, length);
        }

        /// <inheritdoc/>
        public override char GetChar(int ordinal)
        {
            return _enumerator.Current.GetValue<char>(ordinal);
        }

        /// <inheritdoc/>
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return CopyToBuffer(AsSpan<char>(GetValue(ordinal)), dataOffset, buffer, bufferOffset, length);
        }

        /// <inheritdoc/>
        public override string GetDataTypeName(int ordinal)
        {
            return TRow.Columns[ordinal].Type.Name;
        }

        /// <inheritdoc/>
        public override DateTime GetDateTime(int ordinal)
        {
            return _enumerator.Current.GetValue<DateTime>(ordinal);
        }

        /// <inheritdoc/>
        public override decimal GetDecimal(int ordinal)
        {
            return _enumerator.Current.GetValue<decimal>(ordinal);
        }

        /// <inheritdoc/>
        public override double GetDouble(int ordinal)
        {
            return _enumerator.Current.GetValue<double>(ordinal);
        }

        /// <inheritdoc/>
        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Type GetFieldType(int ordinal)
        {
            return TRow.Columns[ordinal].Type;
        }

        /// <inheritdoc/>
        public override float GetFloat(int ordinal)
        {
            return _enumerator.Current.GetValue<float>(ordinal);
        }

        /// <inheritdoc/>
        public override Guid GetGuid(int ordinal)
        {
            return _enumerator.Current.GetValue<Guid>(ordinal);
        }

        /// <inheritdoc/>
        public override short GetInt16(int ordinal)
        {
            return _enumerator.Current.GetValue<short>(ordinal);
        }

        /// <inheritdoc/>
        public override int GetInt32(int ordinal)
        {
            return _enumerator.Current.GetValue<int>(ordinal);
        }

        /// <inheritdoc/>
        public override long GetInt64(int ordinal)
        {
            return _enumerator.Current.GetValue<long>(ordinal);
        }

        /// <inheritdoc/>
        public override string GetName(int ordinal)
        {
            return TRow.Columns[ordinal].Name;
        }

        /// <inheritdoc/>
        public override int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override DataTable GetSchemaTable()
        {
            return TRow.Schema;
        }

        /// <inheritdoc/>
        public override string GetString(int ordinal)
        {
            return _enumerator.Current.GetValue<string>(ordinal);
        }

        /// <inheritdoc/>
        public override object GetValue(int ordinal)
        {
            return _enumerator.Current.GetValue<object>(ordinal);
        }

        /// <inheritdoc/>
        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool IsDBNull(int ordinal)
        {
            return _enumerator.Current.GetValue<object>(ordinal) == default;
        }

        /// <inheritdoc/>
        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool Read()
        {
            return _enumerator.MoveNext();
        }

        /// <inheritdoc/>
        public void LoadDataRow(IEnumerable<TRow> rows)
        {
            _enumerator = rows.GetEnumerator();
        }

        /// <inheritdoc/>
        public void Return()
        {
            pool.Return(this);
        }

        /// <inheritdoc/>
        public bool TryReset()
        {
            _enumerator = default;

            return true;
        }
    }
}