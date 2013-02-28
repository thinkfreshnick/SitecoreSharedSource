using Sitecore.SharedSource.WebApiClient.Interfaces;

namespace Sitecore.SharedSource.WebApiClient.Security
{
    /// <summary>
    /// Represents security credentials for a Sitecore Item Web API request
    /// </summary>
    public class SitecoreCredentials : ISitecoreCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreCredentials" /> class.
        /// </summary>
        public SitecoreCredentials()
        {
            ErrorMessage = "Username and password must be specified";
        }

        #region Implementation of IValidated

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; private set; }

        #endregion

        #region Implementation of ISitecoreCredentials

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [encrypt headers].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [encrypt headers]; otherwise, <c>false</c>.
        /// </value>
        public bool EncryptHeaders { get; set; }

        #endregion
    }
}
