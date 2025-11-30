using Simple.DbExtensions.Tvp.Metadata.Attributes;

using Simple.DbExtensions.Tvp.Tests.Models.Abstracts;

namespace Simple.DbExtensions.Tvp.Tests.Models
{
    [Table(nameof(InternalMetadataTableValued))]
    public sealed class InternalMetadataTableValued : AbstractMetadataTableValued<InternalMetadataTableValued>
    { }
}