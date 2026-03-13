using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationFramework.Utilities
{
    public class ConfigReader
    {
        private static IConfiguration _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetBrowser()
        {
            return _config["Browser"] ?? "chrome";
        }

        public static string GetUrl()
        {
            return _config["Url"] ?? "";
        }

        public static string GetHeadless()
        {
            return _config["Headless"] ?? "false";
        }
    }
}
