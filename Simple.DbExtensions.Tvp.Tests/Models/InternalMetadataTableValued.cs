using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Tests.Models.Abstract;

namespace Simple.DbExtensions.Tvp.Tests.Models
{
    [TableValued(nameof(InternalMetadataTableValued))]
    public sealed class InternalMetadataTableValued : AbstractMetadataTableValued<InternalMetadataTableValued>
    { }
}