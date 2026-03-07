using AutomationFramework.Base;
using AutomationFramework.Pages;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(2)]
   
    public class DashboardTests : BaseTest
    {
        [SetUp]
        public void DashboardSetUp()
        {
            // BaseTest.Setup() already opened browser and navigated to OrangeHRM login
            // Just login here
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.Url.Contains("dashboard"));
        }

        [Test, Order(1), Category("TC_006")]
        [Description("TC_006_DashboardLoads")]
        public void DashboardLoadsTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsDashboardLoaded(),
                "Dashboard header should be visible after login.");
        }

        [Test, Order(2), Category("TC_007")]
        [Description("TC_007_DashboardHeaderText")]
        public void DashboardHeaderTextTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            string header = dashboard.GetDashboardHeaderText();
            Assert.IsTrue(header.Contains("Dashboard"),
                $"Expected 'Dashboard' in header but got: '{header}'");
        }

        [Test, Order(3), Category("TC_008")]
        [Description("TC_008_DashboardUrlContains")]
        public void DashboardUrlTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            string url = dashboard.GetCurrentUrl();
            Assert.IsTrue(url.Contains("dashboard"),
                $"Expected URL to contain 'dashboard' but got: '{url}'");
        }

        [Test, Order(4), Category("TC_009")]
        [Description("TC_009_SidebarMenuVisible")]
        public void SidebarMenuVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsSidebarMenuDisplayed(),
                "Sidebar menu should be visible on dashboard.");
        }

        [Test, Order(5), Category("TC_010")]
        [Description("TC_010_AdminMenuVisible")]
        public void AdminMenuVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsAdminMenuDisplayed(),
                "Admin menu should be visible in sidebar.");
        }

        [Test, Order(6), Category("TC_011")]
        [Description("TC_011_PimMenuVisible")]
        public void PimMenuVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsPimMenuDisplayed(),
                "PIM menu should be visible in sidebar.");
        }

        [Test, Order(7), Category("TC_012")]
        [Description("TC_012_UserDropdownVisible")]
        public void UserDropdownVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsUserDropdownDisplayed(),
                "User dropdown should be visible on dashboard.");
        }

        [Test, Order(8), Category("TC_013")]
        [Description("TC_013_TimeAtWorkWidgetVisible")]
        public void TimeAtWorkWidgetVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsTimeAtWorkWidgetDisplayed(),
                "Time at Work widget should be visible on dashboard.");
        }

        [Test, Order(9), Category("TC_014")]
        [Description("TC_014_LogoutRedirectsToLogin")]
        public void LogoutRedirectsToLoginTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.ClickLogout();
            Assert.IsTrue(driver.Url.Contains("login"),
                "Should redirect to login page after logout.");
        }
    }
}
