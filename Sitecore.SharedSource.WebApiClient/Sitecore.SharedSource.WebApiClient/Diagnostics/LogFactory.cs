using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Sitecore.SharedSource.WebApiClient.Diagnostics
{
    /// <summary>
    /// Factory class for logging messages
    /// </summary>
    public static class LogFactory
    {
        private static readonly ILog Log = Configure();

        /// <summary>
        /// Logs the specified message as information.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Info(string message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// Logs the specified message as a warning.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Warn(string message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// Logs the specified message as an error.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public static void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        /// <summary>
        /// Configures this instance.
        /// </summary>
        /// <returns></returns>
        private static ILog Configure()
        {
            var configFile = new FileInfo(Properties.Settings.Default.ConfigurationFilePath);

            XmlConfigurator.ConfigureAndWatch(configFile);

            return LogManager.GetLogger(typeof(LogFactory));
        }
    }
}
