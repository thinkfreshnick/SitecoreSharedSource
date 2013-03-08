using System;
using System.Net;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send authenticated requests to the Sitecore Item Web API must implement
    /// </summary>
    public interface IAuthenticatedSitecoreDataContext : ISitecoreDataContext
    {
        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        ISitecoreCredentials Credentials { get; }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns></returns>
        HttpWebRequest CreateRequest(Uri uri, SitecoreQueryType type, string postData);

        /// <summary>
        /// Applies the headers.
        /// </summary>
        /// <param name="request">The request.</param>
        void ApplyHeaders(HttpWebRequest request);

        /// <summary>
        /// Applies the encrypted headers.
        /// </summary>
        /// <param name="request">The request.</param>
        void ApplyEncryptedHeaders(HttpWebRequest request);
    }
}
