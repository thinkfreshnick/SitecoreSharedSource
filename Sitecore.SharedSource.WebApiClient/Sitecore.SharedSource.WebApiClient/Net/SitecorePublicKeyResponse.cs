using System;
using System.Net;
using System.Xml.Serialization;
using Sitecore.SharedSource.WebApiClient.Interfaces;

namespace Sitecore.SharedSource.WebApiClient.Net
{
    /// <summary>
    /// Represents a public key response from the Sitecore Web Item API
    /// </summary>
    [Serializable, XmlRoot("RSAKeyValue")]
    public class SitecorePublicKeyResponse : ISitecorePublicKeyResponse
    {
        #region Implementation of IBaseResponse

        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <value>
        /// The info.
        /// </value>
        [XmlIgnore]
        public ISitecoreWebResponseInfo Info { get; set; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>
        /// The status description.
        /// </value>
        [XmlIgnore]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [XmlIgnore]
        public HttpStatusCode StatusCode { get; set; }

        #endregion

        #region Implementation of ISitecorePublicKeyResponse

        /// <summary>
        /// Gets or sets the modulus.
        /// </summary>
        /// <value>
        /// The modulus.
        /// </value>
        public string Modulus { get; set; }

        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public string Exponent { get; set; }

        #endregion

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Modulus) && !string.IsNullOrWhiteSpace(Exponent);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get { return "Modulus and exponent cannot be null or empty"; }
        }

        #endregion
    }
}
