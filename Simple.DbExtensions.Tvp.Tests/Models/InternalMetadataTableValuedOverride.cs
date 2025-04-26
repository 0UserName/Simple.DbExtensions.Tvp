using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Tests.Models.Abstract;

namespace Simple.DbExtensions.Tvp.Tests.Models
{
    [TableValued(nameof(InternalMetadataTableValuedOverride))]
    public sealed class InternalMetadataTableValuedOverride : AbstractMetadataTableValued<InternalMetadataTableValuedOverride>
    {
        /// <summary>
        /// 
        /// </summary>
        [Ordinal(2)]
        public override int Property2
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Ordinal(3)]
        public override int Property3
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Property4
        {
            get;
            set;
        }
    }
}