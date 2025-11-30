namespace Simple.DbExtensions.Tvp.Metadata.Contracts
{
    public interface IColumnExternalMetadata : IColumnInternalMetadata
    {
        /// <summary>
        /// Indicates whether null 
        /// values are allowed in this column 
        /// for rows that belong to the table.
        /// </summary>
        bool AllowDBNull
        {
            get;
        }

        /// <summary>
        /// Maximum length of a text column.
        /// </summary>
        /// 
        /// <remarks>
        /// Ignored for non-text columns.
        /// </remarks>
        int MaxLength
        {
            get;
        }

        /// <summary>
        /// Indicates whether the 
        /// values in each row of 
        /// the column must be 
        /// unique.
        /// </summary>
        bool Unique
        {
            get;
        }
    }
}