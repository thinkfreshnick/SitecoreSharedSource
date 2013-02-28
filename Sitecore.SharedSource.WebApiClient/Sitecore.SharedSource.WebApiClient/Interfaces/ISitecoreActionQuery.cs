namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send action queries to the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreActionQuery : IBaseQuery
    {
        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        string ActionName { get; set; }
    }
}
