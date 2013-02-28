using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.WebApiClient.Util
{
    /// <summary>
    /// Extension methods for the Dictionary type
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts a dictionary instance into a url encoded querystring
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        public static string ToQueryString(this IDictionary<string, string> dictionary)
        {
            if (dictionary == null || dictionary.Count <= 0)
                return string.Empty;

            var parameters = dictionary
                    .Select(keyValuePair => string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value)));

            return string.Join("&", parameters);
        }
    }
}
