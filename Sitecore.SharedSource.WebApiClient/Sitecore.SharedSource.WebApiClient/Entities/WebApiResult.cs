namespace Sitecore.SharedSource.WebApiClient.Entities
{
    /// <summary>
    /// Represents a result returned by the Sitecore Item Web API
    /// </summary>
    public class WebApiResult
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public WebApiItem[] Items { get; set; }

        /// <summary>
        /// Gets the result count.
        /// </summary>
        /// <value>
        /// The result count.
        /// </value>
        public int ResultCount { get; set; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the item ids.
        /// </summary>
        /// <value>
        /// The item ids.
        /// </value>
        public string[] ItemIds { get; set; }
    }
}
