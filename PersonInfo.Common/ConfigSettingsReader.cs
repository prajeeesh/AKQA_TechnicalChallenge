using System.Configuration;

namespace PersonInfo.Common
{
    public class ConfigSettingsReader
    {
        /// <summary>
        /// Retrieves the config value based on the Key provided
        /// </summary>
        /// <param name="configSectionKey"></param>
        /// <returns>config value</returns>
        public static string GetConfigurationValues(string configSectionKey)
        {
            string configValue = ConfigurationManager.AppSettings[configSectionKey];
            return configValue;
        }
    }
}
