using System;
using System.Buffers;

namespace Simple.DbExtensions.Tvp.Pools
{
    public readonly ref struct RentedBuffer<T> : IDisposable
    {
        public ArraySegment<T> Segment
        {
            get;
            private init;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>       
        public void Dispose()
        {
            ArrayPool<T>.Shared.Return(Segment.Array);
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