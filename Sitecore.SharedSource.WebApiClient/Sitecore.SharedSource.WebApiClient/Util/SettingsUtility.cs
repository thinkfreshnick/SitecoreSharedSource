namespace Sitecore.SharedSource.WebApiClient.Util
{
    /// <summary>
    /// Settings focused utility methods
    /// </summary>
    public static class SettingsUtility
    {
        /// <summary>
        /// Gets the default API version.
        /// </summary>
        /// <returns></returns>
        public static int DefaultApiVersion
        {
            get
            {
                return Properties.Settings.Default.DefaultApiVersion > 0
                           ? Properties.Settings.Default.DefaultApiVersion
                           : 1;
            }
        }

        /// <summary>
        /// Gets the default database.
        /// </summary>
        /// <returns></returns>
        public static string DefaultDatabase
        {
            get
            {
                return Properties.Settings.Default.DefaultDatabase;    
            }
        }
    }
}
