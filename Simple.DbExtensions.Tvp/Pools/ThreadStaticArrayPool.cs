using System;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal static class ThreadStaticArrayPool<T>
    {
        [ThreadStatic]
        private static T[] _buffer;

        /// <summary>
        /// Gets 
        /// an array from the pool if one is 
        /// available, otherwise creates one.
        /// </summary>
        public static T[] Rent(int length)
        {
            return _buffer ??= new T[length];
        }

        /// <inheritdoc cref="Rent(int)"/>
        public static T[] Rent(int length, T head)
        {
            Rent(length)[0] = head;

            return _buffer;
        }
    }
}