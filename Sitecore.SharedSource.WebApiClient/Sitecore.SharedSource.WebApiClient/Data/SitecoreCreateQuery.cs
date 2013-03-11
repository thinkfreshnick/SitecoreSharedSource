using System.Collections.Generic;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Util;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Represents a query that creates new items
    /// </summary>
    public class SitecoreCreateQuery : SitecoreQuery, ISitecoreCreateQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreCreateQuery" /> class.
        /// </summary>
        public SitecoreCreateQuery() : base(SitecoreQueryType.Create)
        {
            
        }

        #region Overrides of SitecoreQuery

        /// <summary>
        /// Gets the query string parameter.
        /// </summary>
        /// <value>
        /// The query string parameter.
        /// </value>
        public override KeyValuePair<string, string> QueryParameter
        {
            get { return Validate() ? new KeyValuePair<string, string>(Structs.QueryStringKeys.Query, ParentQuery) : new KeyValuePair<string, string>(Structs.QueryStringKeys.Query, string.Empty); }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var valid = !string.IsNullOrWhiteSpace(Template) &&
                        !string.IsNullOrWhiteSpace(Name) &&
                        QueryType == SitecoreQueryType.Create;

            if (!valid)
                return false;

            // either an item id or query must be provided
            if (!string.IsNullOrWhiteSpace(ItemId))
            {
                valid = ItemId.IsSitecoreId();
            }

            if (valid)
                return true;

            return !string.IsNullOrWhiteSpace(ParentQuery);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public override string ErrorMessage
        {
            get { return "You must at least provide the template, the name of the new item and the parent item. The query type must also be Create"; }
        }

        #endregion

        #region Implementation of ISitecoreCreateQuery

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public string ParentQuery { get; set; }

        /// <summary>
        /// Gets or sets the Name of the new item.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the template id or path for create requests.
        /// </summary>
        /// <value>
        /// The template.		
        /// </value>
        /// <remarks>
        ///	<para>Template paths are relative to the /sitecore/Templates folder</para>
        /// </remarks>
        public string Template { get; set; }

        #endregion

        /// <summary>
        /// Gets the query string parameters.
        /// </summary>
        /// <value>
        /// The query string parameters.
        /// </value>
        public override IDictionary<string, string> QueryStringParameters
        {
            get
            {
                var dictionary = new Dictionary<string, string>
                                     {
                                         { Structs.QueryStringKeys.Name, Name },
                                         { Structs.QueryStringKeys.Template, Template },
                                         { Structs.QueryStringKeys.Database, Database },
                                         { Structs.QueryStringKeys.Payload, Payload.ToString() }
                                     };

                if (FieldsToReturn != null)
                {
                    dictionary.Add(Structs.QueryStringKeys.Fields, string.Join("|", FieldsToReturn));
                }

                if (!string.IsNullOrWhiteSpace(ItemId))
                {
                    dictionary.Add(Structs.QueryStringKeys.ItemId, ItemId);
                }
                else
                {
                    dictionary.Add(QueryParameter.Key, QueryParameter.Value);
                }

                return dictionary;
            }
        }

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
