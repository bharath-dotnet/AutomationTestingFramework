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

        [SetUp]
        public void Setup()
        {
            testStartTime = DateTime.Now;
            driver = BrowserFactory.GetBrowser();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            driver.Navigate().GoToUrl(ConfigReader.GetUrl());

            // Wait for page readyState complete
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>
                ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState").ToString() == "complete");

            string testName =
                TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
                ?? TestContext.CurrentContext.Test.Name;
            LoggerManager.TestStart(testName);
            LoggerManager.Info("Browser opened and login page loaded");
        }

        [TearDown]
        public void TearDown()
        {
            string testName =
                TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
                ?? TestContext.CurrentContext.Test.Name;

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
                LoggerManager.TestFail(testName, TestContext.CurrentContext.Result.Message ?? "");
                try
                {
                    if (driver != null)
                        screenshotPath = ScreenshotHelper.TakeScreenshot(driver, testName);
                }
                catch (Exception ex)
                {
                    LoggerManager.Error("Screenshot failed", ex);
                }
                SimpleReportManager.AddTestResult(testName, browser, "FAIL",
                    screenshotPath, executionTime, testId);
            }
            else
            {
                LoggerManager.TestPass(testName);
                SimpleReportManager.AddTestResult(testName, browser, "PASS",
                    "", executionTime, testId);
            }

            LoggerManager.Info($"Duration: {executionTime}");
            LoggerManager.Info("─────────────────────────────────────────");

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
                LoggerManager.Info("Browser closed");
            }
        }
    }
}
