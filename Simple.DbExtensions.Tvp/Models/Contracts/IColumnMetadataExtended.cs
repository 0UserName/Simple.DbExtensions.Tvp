using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface IColumnMetadataExtended : IColumnMetadata
    {
        /// <summary>
        /// Position of the column in 
        /// the <see cref="DataTable"/>.
        /// </summary>
        int Ordinal
        {
            get;
        }

        /// <summary>
        /// Indicating whether null values 
        /// are allowed in this column for 
        /// rows belonging to the table.
        /// </summary>
        bool AllowDBNull
        {
            get;
        }

        /// <summary>
        /// Maximum length of a text column.
        /// </summary>
        int MaxLength
        {
            get;
        }
    }
}