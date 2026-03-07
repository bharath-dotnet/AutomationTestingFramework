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
            switch (browser)
            {
                case "chrome":
                    return new ChromeDriver(GetChromeOptions());
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new Exception("Browser not supported. Use chrome or edge.");
            }
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();

            // ── Suppress "Change your password" popup ────────────────────────────
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            // ── Suppress other Chrome popups ──────────────────────────────────────
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--no-first-run");
            options.AddArgument("--no-default-browser-check");

            return options;
        }
    }
}
