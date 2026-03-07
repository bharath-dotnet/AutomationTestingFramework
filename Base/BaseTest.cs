using AutomationFramework.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private DateTime testStartTime;

        // ─── RUN BEFORE EACH TEST ─────────────────────────────────────────────────
        [SetUp]
        public void Setup()
        {
            testStartTime = DateTime.Now;
            driver = BrowserFactory.GetBrowser();
            driver.Manage().Window.Maximize();

            // Set page load timeout for slow sites like OrangeHRM
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            driver.Navigate().GoToUrl(ConfigReader.GetUrl());

            // Wait for OrangeHRM login page to fully load
            // OrangeHRM is a React app — DOM loads after JS executes
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>
            {
                string state = ((IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            });
        }

        // ─── RUN AFTER EACH TEST ──────────────────────────────────────────────────
        [TearDown]
        public void TearDown()
        {
            // ── Extract Test Name ─────────────────────────────────────────────────
            string testName =
                TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
                ?? TestContext.CurrentContext.Test.Name;

            // ── Extract Test ID from Category ─────────────────────────────────────
            string testId = "";
            var categories = TestContext.CurrentContext.Test.Properties["Category"];
            if (categories != null)
            {
                foreach (var cat in categories)
                {
                    testId = cat?.ToString() ?? "";
                    break;
                }
            }

            string browser = ConfigReader.GetBrowser();
            string screenshotPath = "";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            TimeSpan duration = DateTime.Now - testStartTime;
            string executionTime = duration.TotalSeconds.ToString("0.00") + " sec";

            if (status == TestStatus.Failed)
            {
                screenshotPath = ScreenshotHelper.TakeScreenshot(driver, testName);
                SimpleReportManager.AddTestResult(testName, browser, "FAIL",
                    screenshotPath, executionTime, testId);
            }
            else
            {
                SimpleReportManager.AddTestResult(testName, browser, "PASS",
                    "", executionTime, testId);
            }

            // ── Dispose WebDriver ─────────────────────────────────────────────────
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
