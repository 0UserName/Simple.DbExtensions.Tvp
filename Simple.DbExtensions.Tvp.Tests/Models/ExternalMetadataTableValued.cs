using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Tests.Models.Abstract;

namespace Simple.DbExtensions.Tvp.Tests.Models
{
    [TableValued(nameof(ExternalMetadataTableValued))]
    public sealed class ExternalMetadataTableValued : AbstractMetadataTableValued<ExternalMetadataTableValued>
    {
        public string Property4
        {
            get;
            set;
        }

        public string Property5
        {
            get;
            set;
        }
    }
}