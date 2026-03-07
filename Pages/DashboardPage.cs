using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By dashboardHeader = By.XPath("//h6[text()='Dashboard']");
        private By userDropdown = By.CssSelector(".oxd-userdropdown-tab");
        private By logoutOption = By.XPath("//a[text()='Logout']");
        private By timeAtWorkWidget = By.XPath("//p[text()='Time at Work']");
        private By sidebarMenu = By.CssSelector(".oxd-sidepanel");
        private By adminMenu = By.XPath("//span[text()='Admin']");
        private By pimMenu = By.XPath("//span[text()='PIM']");

        // ─── Actions ──────────────────────────────────────────────────────────────

        public bool IsDashboardLoaded()
        {
            return IsElementDisplayed(dashboardHeader);
        }

        public string GetDashboardHeaderText()
        {
            return GetElementText(dashboardHeader);
        }

        public bool IsTimeAtWorkWidgetDisplayed()
        {
            return IsElementDisplayed(timeAtWorkWidget);
        }

        public bool IsSidebarMenuDisplayed()
        {
            return IsElementDisplayed(sidebarMenu);
        }

        public bool IsAdminMenuDisplayed()
        {
            return IsElementDisplayed(adminMenu);
        }

        public bool IsPimMenuDisplayed()
        {
            return IsElementDisplayed(pimMenu);
        }

        public bool IsUserDropdownDisplayed()
        {
            return IsElementDisplayed(userDropdown);
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
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
