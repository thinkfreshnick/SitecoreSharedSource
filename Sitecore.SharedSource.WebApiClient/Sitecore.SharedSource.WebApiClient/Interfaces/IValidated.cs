namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent a validated instance must implement
    /// </summary>
    public interface IValidated
    {
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        bool Validate();

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; }
    }
}
