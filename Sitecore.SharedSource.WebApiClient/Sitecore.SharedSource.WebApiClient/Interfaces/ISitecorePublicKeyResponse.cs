namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to represent a Sitecore Item Web API public key must implement
    /// </summary>
    public interface ISitecorePublicKeyResponse : IBaseResponse, IValidated
    {
        /// <summary>
        /// Gets the modulus.
        /// </summary>
        /// <value>
        /// The modulus.
        /// </value>
        string Modulus { get; }

        /// <summary>
        /// Gets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        string Exponent { get; }
    }
}
