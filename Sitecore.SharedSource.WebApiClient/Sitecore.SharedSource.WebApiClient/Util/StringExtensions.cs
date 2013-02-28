namespace Sitecore.SharedSource.WebApiClient.Util
{
    /// <summary>
    /// Extension methods for the string type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the passed string is a valid Sitecore id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>
        ///   <c>true</c> if [is sitecore id] [the specified id]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSitecoreId(this string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            if (id.Length == 38 || id.Length == 36)
            {
                var num1 = 0;

                if (id.Length == 38)
                {
                    if (id[0] != '{' || id[37] != '}')
                    {
                        return false;
                    }

                    num1 = 1;
                }

                for (int i = num1; i < id.Length - num1; i++)
                {
                    char chr = id[i];

                    if ((chr < '0' || chr > '9') && (chr < 'a' || chr > 'f') && (chr < 'A' || chr > 'F'))
                    {
                        if (chr == '-')
                        {
                            int num2 = i - num1;

                            if (num2 != 8 && num2 != 13 && num2 != 18 && num2 != 23)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Ensures the prefix.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public static string EnsurePrefix(this string input, string prefix)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return input.StartsWith(prefix) ? input : string.Concat(prefix, input);
        }
    }
}
