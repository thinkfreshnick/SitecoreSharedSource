using System.Collections.Generic;
using Sitecore.SharedSource.WebApiClient.Interfaces;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Represents a query that utlises Sitecore query
    /// </summary>
    public class SitecoreExpressionQuery : SitecoreQuery, ISitecoreExpressionQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreExpressionQuery" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public SitecoreExpressionQuery(SitecoreQueryType type) : base(type)
        {
            
        }

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Query);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public override string ErrorMessage
        {
            get { return "Query cannot be null or empty"; }
        }

        /// <summary>
        /// Gets the query string parameter.
        /// </summary>
        /// <value>
        /// The query string parameter.
        /// </value>
        public override KeyValuePair<string, string> QueryParameter
        {
            get
            {
                return  Validate() ? new KeyValuePair<string, string>(Structs.QueryStringKeys.Query, Query) : new KeyValuePair<string, string>(Structs.QueryStringKeys.Query, string.Empty);
            }
        }

        #endregion

        #region Implementation of ISitecoreExpressionQuery

        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public string Query { get; set; }

        #endregion
    }
}
