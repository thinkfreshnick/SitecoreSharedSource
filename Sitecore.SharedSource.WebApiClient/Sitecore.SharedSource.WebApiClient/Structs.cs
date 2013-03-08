namespace Sitecore.SharedSource.WebApiClient
{
    /// <summary>
    /// Constants
    /// </summary>
    public class Structs
    {
        /// <summary>
        /// Querystring Keys
        /// </summary>
        public struct QueryStringKeys
        {
            /// <summary>
            /// The item id querystring key
            /// </summary>
            public const string ItemId = "sc_itemid";

            /// <summary>
            /// The item version querystring key
            /// </summary>
            public const string ItemVersion = "sc_itemversion";

            /// <summary>
            /// The database querystring key
            /// </summary>
            public const string Database = "sc_database";

            /// <summary>
            /// The language querystring key
            /// </summary>
            public const string Language = "language";

            /// <summary>
            /// The fields querystring key
            /// </summary>
            public const string Fields = "fields";

            /// <summary>
            /// The payload querystring key
            /// </summary>
            public const string Payload = "payload";

            /// <summary>
            /// The scope querystring key
            /// </summary>
            public const string Scope = "scope";

            /// <summary>
            /// The query querystring key
            /// </summary>
            public const string Query = "query";

            /// <summary>
            /// The page querystring key
            /// </summary>
            public const string Page = "page";

            /// <summary>
            /// The page size querystring key
            /// </summary>
            public const string PageSize = "pageSize";

            /// <summary>
            /// The extract BLOB querystring key
            /// </summary>
            public const string ExtractBlob = "extractblob";

            /// <summary>
            /// The template querystring key
            /// </summary>
            public const string Template = "template";

            /// <summary>
            /// The name querystring key
            /// </summary>
            public const string Name = "name";
        }

        /// <summary>
        /// Authentication Headers
        /// </summary>
        public struct AuthenticationHeaders
        {
            /// <summary>
            /// The user name authentication header
            /// </summary>
            public const string UserName = "X-Scitemwebapi-Username";

            /// <summary>
            /// The password authentication header
            /// </summary>
            public const string Password = "X-Scitemwebapi-Password";

            /// <summary>
            /// The encrypted authentication header
            /// </summary>
            public const string Encrypted = "X-Scitemwebapi-Encrypted";
        }
    }
}
