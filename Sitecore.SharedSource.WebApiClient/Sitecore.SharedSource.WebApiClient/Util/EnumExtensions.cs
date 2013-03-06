namespace Sitecore.SharedSource.WebApiClient.Util
{
    /// <summary>
    /// Enum extension methods
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the SitecoreItemScope instance to a valid querystring parameter value
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns></returns>
        public static string ToScopeParameter(this SitecoreItemScope scope)
        {
            var output = string.Empty;

            switch (scope)
            {
                case SitecoreItemScope.Self:
                    output = "s";
                    break;
                case SitecoreItemScope.Children:
                    output = "c";
                    break;
                case SitecoreItemScope.Parent:
                    output = "p";
                    break;
            }

            return output;
        }

        /// <summary>
        /// To the HTTP method.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string ToHttpMethod(this SitecoreQueryType type)
        {
            var output = "GET";

            switch (type)
            {
                case SitecoreQueryType.Read:
                    output = "GET";
                    break;
                //case SitecoreQueryType.Create:
                //    output = "POST";
                //    break;
                case SitecoreQueryType.Delete:
                    output = "DELETE";
                    break;
                //case SitecoreQueryType.MediaCreate:
                //    output = "POST";
                //    break;
                //case SitecoreQueryType.Update:
                //    output = "PUT";
                //    break;
            }

            return output;
        }
    }
}
