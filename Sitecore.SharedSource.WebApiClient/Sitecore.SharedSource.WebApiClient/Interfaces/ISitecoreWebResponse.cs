using Sitecore.SharedSource.WebApiClient.Entities;

namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent a response from the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreWebResponse : IBaseResponse
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        WebApiResult Result { get; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        WebApiError Error { get; }
    }
}
