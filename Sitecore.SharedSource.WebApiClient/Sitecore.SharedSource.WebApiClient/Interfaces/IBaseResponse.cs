using System.Net;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent a response from the Sitecore Item Web API must implement
    /// </summary>
    public interface IBaseResponse
    {
        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <value>
        /// The info.
        /// </value>
        ISitecoreWebResponseInfo Info { get; set; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>
        /// The status description.
        /// </value>
        string StatusDescription { get; set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        HttpStatusCode StatusCode { get; set; }
    }
}
