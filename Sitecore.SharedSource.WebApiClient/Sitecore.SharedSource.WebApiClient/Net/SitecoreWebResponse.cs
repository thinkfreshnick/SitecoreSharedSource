using System.Net;
using Sitecore.SharedSource.WebApiClient.Entities;
using Sitecore.SharedSource.WebApiClient.Interfaces;

namespace Sitecore.SharedSource.WebApiClient.Net
{
    /// <summary>
    /// Represents a response from the Sitecore Web Item API
    /// </summary>
    public class SitecoreWebResponse : ISitecoreWebResponse
    {
        #region Implementation of ISitecoreWebResponse

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>
        /// The status description.
        /// </value>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public WebApiResult Result { get; set; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public WebApiError Error { get; set; }

        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <value>
        /// The info.
        /// </value>
        public ISitecoreWebResponseInfo Info { get; set; }

        #endregion
    }
}
