using System;
using System.Net;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send requests to the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreDataContext
    {
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        T GetResponse<T>(IBaseQuery query) where T : class, IBaseResponse, new();

        /// <summary>
        /// Gets the specified URI.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="type">The type.</param>
        /// <param name="responseFormat">The response format.</param>
        /// <param name="scResponse">The sc response.</param>
        /// <returns></returns>
        T Get<T>(Uri uri, SitecoreQueryType type, ResponseFormat responseFormat, T scResponse) where T: class, IBaseResponse;

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        string HostName { get; set; }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns></returns>
        HttpWebRequest CreateRequest(Uri uri, SitecoreQueryType type);

        /// <summary>
        /// Deserializes the Json response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        T DeserializeJsonResponse<T>(string response) where T: IBaseResponse;

        /// <summary>
        /// Deserializes the XML response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        T DeserializeXmlResponse<T>(string response) where T : IBaseResponse;

        /// <summary>
        /// Gets the public key.
        /// </summary>
        /// <returns></returns>
        ISitecorePublicKeyResponse GetPublicKey();
    }
}
