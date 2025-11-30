using System;
using System.Runtime.CompilerServices;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal readonly ref struct UnsafeResizeScope(object[] array) : IDisposable
    {
        /// <summary>
        /// See: <see href="https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/src/System/Runtime/CompilerServices/RuntimeHelpers.CoreCLR.cs#L297">RuntimeHelpers.RawArrayData</see>
        /// </summary>
        private sealed class RawArrayData
        {
            public uint Length; // Array._numComponents padded to IntPtr
#if TARGET_64BIT
        public uint Padding;
#endif
            public byte Data;
        }

        /// <summary>
        /// Original array length.
        /// </summary>
        private readonly int _length = array.Length;

        /// <summary>
        /// Resizes the underlying 
        /// array to the specified 
        /// length.
        /// </summary>
        public void Resize(int length)
        {
            Unsafe.As<RawArrayData>(array).Length = (uint)length;
        }

        /// <inheritdoc cref="Resize"/>
        public void Dispose()
        {
            Resize(_length);
        }

        public UnsafeResizeScope(object[] array, int length) : this(array)
        {
            Resize(length);
        }
    }
}