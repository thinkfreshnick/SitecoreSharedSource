namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send item queries to the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreItemQuery
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>
        /// The item id.
        /// </value>
        string ItemId { get; set; }
    }
}
