using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace AutomationFramework.Utilities
{
    public class BrowserFactory
    {
        public static IWebDriver GetBrowser()
        {
            string browser = ConfigReader.GetBrowser().ToLower();

            if (browser == "edge")
            {
                var edgeOptions = new EdgeOptions();
                if (IsHeadless())
                {
                    edgeOptions.AddArgument("--headless");
                    edgeOptions.AddArgument("--no-sandbox");
                    edgeOptions.AddArgument("--disable-gpu");
                    edgeOptions.AddArgument("--disable-dev-shm-usage");
                }
                return new EdgeDriver(edgeOptions);
            }
            else
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--disable-gpu");
                chromeOptions.AddArgument("--window-size=1920,1080");

                if (IsHeadless())
                {
                    chromeOptions.AddArgument("--headless");
                }

                return new ChromeDriver(chromeOptions);
            }
        }

        private static bool IsHeadless()
        {
            // Run headless in CI/CD environment
            string ci = Environment.GetEnvironmentVariable("CI") ?? "";
            string headless = ConfigReader.GetHeadless();
            return ci == "true" || headless.ToLower() == "true";
        }
    }
}
