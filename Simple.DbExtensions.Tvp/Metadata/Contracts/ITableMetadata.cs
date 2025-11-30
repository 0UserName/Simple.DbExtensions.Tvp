namespace Simple.DbExtensions.Tvp.Metadata.Contracts
{
    public interface ITableMetadata
    {
        /// <summary>
        /// Parameter type name.
        /// </summary>
        /// 
        /// <remarks>
        /// Type name must match the name of a 
        /// compatible type previously created 
        /// on the server.
        /// </remarks>
        string Name
        {
            get;
        }

        /// <summary>
        /// Maximum number of 
        /// objects to retain 
        /// in a pool.
        /// </summary>
        int MaximumRetained
        {
            get;
        }
    }
}