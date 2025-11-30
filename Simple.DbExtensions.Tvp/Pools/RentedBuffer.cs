using System;
using System.Buffers;

using System.Diagnostics;

namespace Simple.DbExtensions.Tvp.Pools
{
    [DebuggerDisplay("Count = { Segment.Count }, ArrayLength = { Segment.Array.Length }")]
    internal readonly ref struct RentedBuffer<T> : IDisposable
    {
        public ArraySegment<T> Segment
        {
            get;
            private init;
        }

        public UnsafeResizeScope EnterToUnsafeResizeScope(int length)
        {
            return new UnsafeResizeScope(Segment.Array as object[], length);
        }

        /// <inheritdoc/>       
        public void Dispose()
        {
            ArrayPool<T>.Shared.Return(Segment.Array, true);
        }

        public RentedBuffer(int length)
        {
            Segment = new ArraySegment<T>(ArrayPool<T>.Shared.Rent(length), 0, length);
        }

        public RentedBuffer(T obj) : this(1)
        {
            Segment.Array[0] = obj;
        }
    }
}