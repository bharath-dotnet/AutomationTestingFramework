using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Pages
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By profileHeader = By.XPath("//h6[text()='Personal Details']");
        private By firstNameField = By.XPath("//input[@name='firstName']");
        private By lastNameField = By.XPath("//input[@name='lastName']");
        private By saveButton = By.XPath("//button[@type='submit']");
        private By userDropdown = By.CssSelector(".oxd-userdropdown-tab");
        private By logoutOption = By.XPath("//a[text()='Logout']");
        private By personalDetailsTab = By.XPath("//a[text()='Personal Details']");
        private By contactDetailsTab = By.XPath("//a[text()='Contact Details']");
        private By emergencyTab = By.XPath("//a[text()='Emergency Contacts']");

        // ─── Actions ──────────────────────────────────────────────────────────────

        /// <summary>Navigate directly to My Info page via URL — more reliable than dropdown click.</summary>
        public void NavigateToMyInfo()
        {
            // Direct URL navigation — bypasses dropdown click issues entirely
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewMyDetails");

            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(d => IsElementDisplayed(profileHeader));
        }

        public bool IsProfilePageLoaded()
        {
            return IsElementDisplayed(profileHeader);
        }

        public string GetProfileHeaderText()
        {
            return GetElementText(profileHeader);
        }

        public bool IsFirstNameFieldDisplayed()
        {
            return IsElementDisplayed(firstNameField);
        }

        public bool IsLastNameFieldDisplayed()
        {
            return IsElementDisplayed(lastNameField);
        }

        public bool IsSaveButtonDisplayed()
        {
            return IsElementDisplayed(saveButton);
        }

        public bool IsPersonalDetailsTabDisplayed()
        {
            return IsElementDisplayed(personalDetailsTab);
        }

        public bool IsContactDetailsTabDisplayed()
        {
            return IsElementDisplayed(contactDetailsTab);
        }

        public bool IsEmergencyTabDisplayed()
        {
            return IsElementDisplayed(emergencyTab);
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void ClickLogout()
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var dropdown = WaitForElement(userDropdown);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", dropdown);
            w.Until(d => IsElementDisplayed(logoutOption));
            var logout = WaitForElement(logoutOption);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", logout);
            w.Until(d => d.Url.Contains("login"));
        }
    }
}
