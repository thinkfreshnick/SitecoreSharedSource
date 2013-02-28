using System;
using System.Collections.Generic;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send queries to the Sitecore Item Web API must implement
    /// </summary>
    public interface IBaseQuery : IValidated
    {
        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>
        /// The API version.
        /// </value>
        int ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        string Database { get; set; }

        /// <summary>
        /// Gets the query string parameters.
        /// </summary>
        /// <value>
        /// The query string parameters.
        /// </value>
        IDictionary<string, string> QueryStringParameters { get; }

        /// <summary>
        /// Gets or sets the type of the query.
        /// </summary>
        /// <value>
        /// The type of the query.
        /// </value>
        SitecoreQueryType QueryType { get; }

        /// <summary>
        /// Builds the URI.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        Uri BuildUri(string hostName);

        /// <summary>
        /// Gets the response format.
        /// </summary>
        /// <value>
        /// The response format.
        /// </value>
        ResponseFormat ResponseFormat { get; }
    }
}
