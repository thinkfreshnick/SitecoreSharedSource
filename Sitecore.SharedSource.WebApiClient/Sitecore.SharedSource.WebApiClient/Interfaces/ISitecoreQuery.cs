using System.Collections.Generic;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send queries to the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreQuery : IBaseQuery
    {
        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        SitecorePayload Payload { get; set; }

        /// <summary>
        /// Gets or sets the item version.
        /// </summary>
        /// <value>
        /// The item version.
        /// </value>
        int ItemVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [extract BLOB].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [extract BLOB]; otherwise, <c>false</c>.
        /// </value>
        bool ExtractBlob { get; set; }

        /// <summary>
        /// Gets or sets the query scope.
        /// </summary>
        /// <value>
        /// The query scope.
        /// </value>
        IEnumerable<SitecoreItemScope> QueryScope { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        int Page { get; set; }

        /// <summary>
        /// Sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the fields to return in the response.
        /// </summary>
        /// <value>
        /// The fields to return.
        /// </value>
        IEnumerable<string> FieldsToReturn { get; set; }

        /// <summary>
        /// Gets or sets fields and their values for update or create operations.
        /// </summary>
        /// <value>
        /// The fields to update.
        /// </value>
        IDictionary<string, string> FieldsToUpdate { get; set; }

        /// <summary>
        /// Gets the query parameter.
        /// </summary>
        /// <value>
        /// The query parameter.
        /// </value>
        KeyValuePair<string, string> QueryParameter { get; } 
    }
}
