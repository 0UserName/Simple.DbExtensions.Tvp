using Simple.DbExtensions.Tvp.Metadata.Attributes;

using Simple.DbExtensions.Tvp.Tests.Models.Abstracts;

namespace Simple.DbExtensions.Tvp.Tests.Models
{
    [Table(nameof(ExternalMetadataTableValued))]
    public sealed class ExternalMetadataTableValued : AbstractMetadataTableValued<ExternalMetadataTableValued>
    {
        public int Property4
        {
            get;
            set;
        }

        public int Property5
        {
            get;
            set;
        }
    }
}