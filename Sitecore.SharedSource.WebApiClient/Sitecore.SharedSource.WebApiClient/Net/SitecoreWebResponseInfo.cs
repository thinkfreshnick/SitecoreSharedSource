using System;
using Sitecore.SharedSource.WebApiClient.Interfaces;

namespace Sitecore.SharedSource.WebApiClient.Net
{
    /// <summary>
    /// Represents meta data about a response from the Sitecore Web Item API
    /// </summary>
    public class SitecoreWebResponseInfo : ISitecoreWebResponseInfo
    {
        #region Implementation of ISitecoreWebResponseInfo

        /// <summary>
        /// Gets the response time.
        /// </summary>
        /// <value>
        /// The response time.
        /// </value>
        public TimeSpan ResponseTime { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>
        /// The stack trace.
        /// </value>
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public Uri Uri { get; set; }

        #endregion
    }
}
