namespace Sitecore.SharedSource.WebApiClient
{
    /// <summary>
    /// Read is currently the only supported operation, more to follow
    /// </summary>
    public enum SitecoreQueryType
    {
        /// <summary>
        /// Read only query
        /// </summary>
        Read,
        /// <summary>
        /// Creates new items
        /// </summary>
        //Create,
        //Update,
        /// <summary>
        /// Deletes existing items
        /// </summary>
        Delete,
        //MediaCreate
    }

    /// <summary>
    /// Sitecore Web Item API payload type
    /// </summary>
    public enum SitecorePayload
    {
        /// <summary>
        /// No fields are returned in the service response
        /// </summary>
        Min = 1,
        /// <summary>
        /// Only content fields are returned in the service response
        /// </summary>
        Content = 0,
        /// <summary>
        /// All the item fields, including content and standard fields, are returned in the service response.
        /// </summary>
        Full = 2
    }

    /// <summary>
    /// Sitecore Web Item API Item Scope
    /// </summary>
    public enum SitecoreItemScope
    {
        /// <summary>
        /// Scoped to the item
        /// </summary>
        Self,
        /// <summary>
        /// Scoped to the items children
        /// </summary>
        Children,
        /// <summary>
        /// Scoped to the items parent
        /// </summary>
        Parent
    }

    /// <summary>
    /// Sitecore Web Item API response format
    /// </summary>
    public enum ResponseFormat
    {
        /// <summary>
        /// Json response format
        /// </summary>
        Json,
        /// <summary>
        /// XML response format
        /// </summary>
        Xml
    }
}
