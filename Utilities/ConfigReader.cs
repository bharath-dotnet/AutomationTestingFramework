using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationFramework.Utilities
{
    public class ConfigReader
    {
        private static IConfigurationRoot configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string GetBrowser()
        {
            return configuration["browser"];
        }

        public static string GetUrl()
        {
            return configuration["url"];
        }

        public static string GetPaymentUrl()
        {
            return configuration["paymentUrl"];
        }
    }
}
