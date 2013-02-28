namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send expression queries to the Sitecore Item Web API must implement
    /// </summary>
    interface ISitecoreExpressionQuery
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        string Query { get; set; }
    }
}
