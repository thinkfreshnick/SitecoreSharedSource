using System;
using System.Collections.Generic;
using Sitecore.SharedSource.WebApiClient.Diagnostics;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Util;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Represents a sitecore query that performs an action
    /// </summary>
    public class SitecoreActionQuery : ISitecoreActionQuery
    {
        private int _apiVersion;

        private string _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreActionQuery" /> class.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="format">The format.</param>
        public SitecoreActionQuery(string actionName, ResponseFormat format = ResponseFormat.Xml)
        {
            ActionName = actionName;
            ResponseFormat = format;

            QueryType = SitecoreQueryType.Read;

            ErrorMessage = "You must provide an action name for an action query";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreActionQuery" /> class.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameters">The parameters.</param>
        public SitecoreActionQuery(string actionName, IDictionary<string, string> parameters) : this(actionName)
        {
            QueryStringParameters = parameters;
        }

        #region Implementation of IBaseQuery

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
        /// Gets the query string parameters.
        /// </summary>
        /// <value>
        /// The query string parameters.
        /// </value>
        public IDictionary<string, string> QueryStringParameters { get; private set; }

        /// <summary>
        /// Gets or sets the type of the query.
        /// </summary>
        /// <value>
        /// The type of the query.
        /// </value>
        public SitecoreQueryType QueryType { get; private set; }

        /// <summary>
        /// Builds the URI.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public virtual Uri BuildUri(string hostName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException("hostName");
            }

            if (!Validate())
            {
                throw new InvalidOperationException("You cannot build a web service URI with an invalid data query");
            }

            try
            {
                var uriSuffix = string.Format("{0}/-/item/v{1}/-/actions/{2}?", hostName.TrimEnd('/'), ApiVersion, ActionName);

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

        #endregion

        #region Implementation of ISitecoreActionQuery

        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName { get; set; }

        #endregion

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(ActionName);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; private set; }

        #endregion
    }
}
