using System;
using System.Collections.Generic;
using System.Globalization;
using Sitecore.SharedSource.WebApiClient.Diagnostics;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Util;
using System.Linq;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Abstract representation of a query to the Sitecore Item Web API
    /// </summary>
    /// <remarks>
    /// <para>
    /// All query classes should inherit from SitcoreQuery
    /// </para>
    /// </remarks>
    public abstract class SitecoreQuery : ISitecoreQuery
    {
        private int _apiVersion;

        private string _database;

        private int _itemVersion;

        private string _language;

        private IEnumerable<SitecoreItemScope> _queryScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreQuery" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        protected SitecoreQuery(SitecoreQueryType type, ResponseFormat format = ResponseFormat.Json)
        {
            QueryType = type;
            ResponseFormat = format;
        }

        #region Implementation of ISitecoreQuery

        /// <summary>
        /// Gets or sets the type of the query.
        /// </summary>
        /// <value>
        /// The type of the query.
        /// </value>
        public SitecoreQueryType QueryType { get; set; }

        /// <summary>
        /// Builds the URI.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public virtual Uri BuildUri(string hostName)
        {
            if (!Validate())
            {
                throw new InvalidOperationException("You cannot build a web service URI with an invalid data query");
            }

            try
            {
                var uriSuffix = string.Format("{0}/-/item/v{1}/?", hostName.TrimEnd('/'), ApiVersion);

                var uri = string.Format("{0}{1}", uriSuffix, QueryStringParameters.ToQueryString());

                return new Uri(uri);
            }
            catch (Exception ex)
            {
                LogFactory.Error("Could not build a URI for the data query", ex);
            }

            return null;
        }

        /// <summary>
        /// Gets the response format.
        /// </summary>
        /// <value>
        /// The response format.
        /// </value>
        public ResponseFormat ResponseFormat { get; set; }

        /// <summary>
        /// Gets or sets the fields used for create requests.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public IDictionary<string, string> FieldsToUpdate { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        public SitecorePayload Payload { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>
        /// The API version.
        /// </value>
        public int ApiVersion
        {
            get { return _apiVersion > 0 ? _apiVersion : SettingsUtility.DefaultApiVersion; }
            set { _apiVersion = value; }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public string Database
        {
            get { return _database ?? SettingsUtility.DefaultDatabase; }
            set { _database = value; }
        }

        /// <summary>
        /// Gets or sets the item version.
        /// </summary>
        /// <value>
        /// The item version.
        /// </value>
        public int ItemVersion
        {
            get { return _itemVersion > 0 ? _itemVersion : 1; }
            set { _itemVersion = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [extract BLOB].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [extract BLOB]; otherwise, <c>false</c>.
        /// </value>
        public bool ExtractBlob { get; set; }

        /// <summary>
        /// Gets or sets the query scope.
        /// </summary>
        /// <value>
        /// The query scope.
        /// </value>
        public IEnumerable<SitecoreItemScope> QueryScope
        {
            get { return _queryScope ?? new[] { SitecoreItemScope.Self }; }
            set { _queryScope = value; }
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language
        {
            get { return _language ?? "default"; }
            set { _language = value; }
        }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public IEnumerable<string> FieldsToReturn { get; set; }

        /// <summary>
        /// Gets the query parameter.
        /// </summary>
        /// <value>
        /// The query parameter.
        /// </value>
        public abstract KeyValuePair<string, string> QueryParameter { get; }

        /// <summary>
        /// Gets the query string parameters.
        /// </summary>
        /// <value>
        /// The query string parameters.
        /// </value>
        public virtual IDictionary<string, string> QueryStringParameters
        {
            get
            {
                var dictionary = new Dictionary<string, string>
                                     {
                                         { Structs.QueryStringKeys.Database, Database },
                                         { Structs.QueryStringKeys.ExtractBlob, ExtractBlob.ToIntString() },
                                         { Structs.QueryStringKeys.ItemVersion,ItemVersion.ToString(CultureInfo.InvariantCulture) },
                                         { Structs.QueryStringKeys.Language, Language },
                                         { Structs.QueryStringKeys.Payload, Payload.ToString() },
                                         { Structs.QueryStringKeys.Scope, string.Join("|", QueryScope.Select(x => x.ToScopeParameter())) }
                                     };

                // the Sitecore web service will return a 500 code if specifying a page size <= 0
                if (PageSize > 0)
                {
                    dictionary.Add(Structs.QueryStringKeys.Page, Page.ToString(CultureInfo.InvariantCulture));
                    dictionary.Add(Structs.QueryStringKeys.PageSize, PageSize.ToString(CultureInfo.InvariantCulture));
                }

                if (FieldsToReturn != null)
                {
                    dictionary.Add(Structs.QueryStringKeys.Fields, string.Join("|", FieldsToReturn));
                }

                dictionary.Add(QueryParameter.Key, QueryParameter.Value);

                return dictionary;
            }
        }

        #endregion

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate()
        {
            return !string.IsNullOrWhiteSpace(QueryParameter.Key) &&
                   !string.IsNullOrWhiteSpace(QueryParameter.Value);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public abstract string ErrorMessage { get; }

        #endregion
    }
}
