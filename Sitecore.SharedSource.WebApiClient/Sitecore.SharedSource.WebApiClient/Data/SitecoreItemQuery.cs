using System.Collections.Generic;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Util;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Represents a query that searches for a single item
    /// </summary>
    public class SitecoreItemQuery : SitecoreQuery, ISitecoreItemQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreItemQuery" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public SitecoreItemQuery(SitecoreQueryType type) : base(type)
        {
            
        }

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return ItemId.IsSitecoreId();
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public override string ErrorMessage
        {
            get { return "The specified ItemId is not a valid Sitecore Id"; }
        }

        /// <summary>
        /// Gets the query string parameter.
        /// </summary>
        /// <value>
        /// The query string parameter.
        /// </value>
        public override KeyValuePair<string, string> QueryParameter
        {
            get { return Validate() ? new KeyValuePair<string, string>(Structs.QueryStringKeys.ItemId, ItemId) : new KeyValuePair<string, string>(Structs.QueryStringKeys.ItemId, string.Empty); }
        }

        #endregion

        #region Implementation of ISitecoreItemQuery

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>
        /// The item id.
        /// </value>
        public string ItemId { get; set; }

        #endregion
    }
}
