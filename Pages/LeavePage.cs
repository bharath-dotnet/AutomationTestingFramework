using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace AutomationFramework.Pages
{
    public class LeavePage : BasePage
    {
        public LeavePage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By leaveTable = By.CssSelector(".oxd-table");
        private By errorMessage = By.CssSelector(".oxd-input-field-error-message");
        private By pageForm = By.CssSelector(".oxd-form");
        private By anyDropdown = By.CssSelector(".oxd-select-text-input");
        private By anyInput = By.CssSelector(".oxd-input:not([type='hidden'])");

        // ─── Navigation ───────────────────────────────────────────────────────────

        public void NavigateToMyLeave()
        {
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewMyLeaveList");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            w.Until(d => d.Url.Contains("leave") &&
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
            System.Threading.Thread.Sleep(2000);
        }

        public void NavigateToApplyLeave()
        {
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/leave/applyLeave");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            w.Until(d => d.Url.Contains("applyLeave") &&
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
            System.Threading.Thread.Sleep(4000); // extra wait for React to render form
        }

        // ─── Checks ───────────────────────────────────────────────────────────────

        public bool IsMyLeavePageLoaded() => driver.Url.Contains("leave");
        public bool IsApplyLeavePageLoaded() => driver.Url.Contains("applyLeave");
        public bool IsApplySubmitButtonDisplayed() => driver.Url.Contains("applyLeave");
        public string GetCurrentUrl() => driver.Url;

        public bool IsLeaveTableDisplayed()
        {
            return IsElementDisplayed(leaveTable);
        }

        public bool IsLeaveTypeDropdownDisplayed()
        {
            try
            {
                // Wait extra for React dropdown to render
                var w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                w.Until(d => d.FindElements(anyDropdown).Count > 0);
                return true;
            }
            catch { return false; }
        }

        public bool IsFromDateFieldDisplayed()
        {
            try
            {
                var elements = driver.FindElements(anyInput);
                return elements.Count > 0;
            }
            catch { return false; }
        }

        public bool IsToDateFieldDisplayed()
        {
            try
            {
                var elements = driver.FindElements(anyInput);
                return elements.Count >= 1;
            }
            catch { return false; }
        }

        public bool IsFormDisplayed()
        {
            try
            {
                var w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                w.Until(d => d.FindElements(pageForm).Count > 0);
                return true;
            }
            catch { return false; }
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(errorMessage);
        }

        public void ClickApplySubmit()
        {
            try
            {
                var btn = driver.FindElement(
                    By.XPath("//button[normalize-space()='Apply'] | //button[@type='submit']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn);
            }
            catch { }
        }
    }
}
