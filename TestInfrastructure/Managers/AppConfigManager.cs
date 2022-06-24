using System;
using System.Configuration;
using static Jiminny.UITests.TestInrastructure.Drivers.Browser;

namespace Jiminny.UITests.TestInfrastructure.Managers
{
    public static class AppConfigManager
    {
        public static BrowserType GetBrowser()
        {
            string browser = GetConfigurationValue("Browser");

            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public static string GetBaseUrl()
        {
            return GetConfigurationValue("BaseUrl");
        }

        private static string GetConfigurationValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
