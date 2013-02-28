using System;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent Sitecore Item Web API response info must implement
    /// </summary>
    public interface ISitecoreWebResponseInfo
    {
        /// <summary>
        /// Gets the response time.
        /// </summary>
        /// <value>
        /// The response time.
        /// </value>
        TimeSpan ResponseTime { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        int Length { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>
        /// The stack trace.
        /// </value>
        string StackTrace { get; set; }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        Uri Uri { get; set; }
    }
}
