namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent Sitecore Item Web API credentials must implement
    /// </summary>
    public interface ISitecoreCredentials : IValidated
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [encrypt headers].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [encrypt headers]; otherwise, <c>false</c>.
        /// </value>
        bool EncryptHeaders { get; set; }
    }
}
