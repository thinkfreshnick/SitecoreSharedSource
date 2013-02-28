namespace Sitecore.SharedSource.WebApiClient.Util
{
    /// <summary>
    /// Extension methods for the bool type
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// To the int string.
        /// </summary>
        /// <param name="b">if set to <c>true</c> [b].</param>
        /// <returns></returns>
        public static string ToIntString(this bool b)
        {
            return b ? "1" : "0";
        }
    }
}
