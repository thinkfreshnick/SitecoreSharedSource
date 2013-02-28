using System;
using System.Net;
using Sitecore.SharedSource.WebApiClient.Diagnostics;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Net;
using Sitecore.SharedSource.WebApiClient.Util;

namespace Sitecore.SharedSource.WebApiClient.Data
{
    /// <summary>
    /// Represents an authenticated Sitecore data context
    /// </summary>
    public class AuthenticatedSitecoreDataContext : SitecoreDataContext, IAuthenticatedSitecoreDataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedSitecoreDataContext" /> class.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="isSecure">if set to <c>true</c> [is secure].</param>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="System.ArgumentException">credentials</exception>
        public AuthenticatedSitecoreDataContext(string hostName, ISitecoreCredentials credentials, bool isSecure = false) : base(hostName, isSecure)
        {
            if(isSecure && credentials.EncryptHeaders)
            {
                throw new InvalidOperationException("If you use an SSL connection, the credentials must not be encrypted. The server takes care of header encryption.");
            }

            if (credentials == null)
            {
                throw new ArgumentNullException("credentials", "credentials cannot be null when creating a new instance of AuthenticatedSitecoreDataContext");
            }

            if (!credentials.Validate())
            {
                throw new ArgumentException(credentials.ErrorMessage, "credentials");
            }

            Credentials = credentials;
        }

        #region Implementation of IAuthenticatedSitecoreDataContext

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        public ISitecoreCredentials Credentials { get; private set; }

        /// <summary>
        /// Applies the headers.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ApplyHeaders(HttpWebRequest request)
        {
            if (request == null)
                return;

            if (Credentials.EncryptHeaders)
            {
                ApplyEncryptedHeaders(request);
                return;
            }

            request.Headers.Add(Structs.AuthenticationHeaders.UserName, Credentials.UserName);
            request.Headers.Add(Structs.AuthenticationHeaders.Password, Credentials.Password);
        }

        /// <summary>
        /// Applies the encrypted headers.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ApplyEncryptedHeaders(HttpWebRequest request)
        {
            if (request == null)
                return;

            var key = GetPublicKey();

            if (key != null)
            {
                request.Headers.Add(Structs.AuthenticationHeaders.UserName,
                                    SecurityUtil.EncryptHeaderValue(Credentials.UserName, key));
                request.Headers.Add(Structs.AuthenticationHeaders.Password,
                                    SecurityUtil.EncryptHeaderValue(Credentials.Password, key));
                request.Headers.Add(Structs.AuthenticationHeaders.Encrypted, "1");
            }
            else
            {
                LogFactory.Warn("Could not retrieve a public key to send encypted headers, authentication headers were not passed with the request");
            }
        }

        #endregion

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public override HttpWebRequest CreateRequest(Uri uri, SitecoreQueryType type)
        {
            var request = base.CreateRequest(uri, type);

            ApplyHeaders(request);

            return request;
        }

        /// <summary>
        /// Gets the public key.
        /// </summary>
        /// <returns></returns>
        public override ISitecorePublicKeyResponse GetPublicKey()
        {
            var query = new SitecoreActionQuery("getpublickey");

            // do not authenticate the call to get public key otherwise you will end up in an eternal loop
            // as the authentication routine itself calls GetPublicKey()

            ISitecorePublicKeyResponse response = new SitecoreDataContext(HostName).GetResponse<SitecorePublicKeyResponse>(query);

            return response.Validate() ? response : null;
        }
    }
}
