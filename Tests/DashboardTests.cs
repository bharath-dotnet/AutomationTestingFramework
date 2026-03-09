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
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));
        }

        [Test, Order(1), Category("TC_006")]
        [Description("TC_006_DashboardLoads")]
        public void DashboardLoadsTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsDashboardLoaded(), "Dashboard should be loaded.");
        }

        [Test, Order(2), Category("TC_007")]
        [Description("TC_007_DashboardUrlContains")]
        public void DashboardUrlTest()
        {
            Assert.IsTrue(driver.Url.Contains("dashboard"), "URL should contain 'dashboard'.");
        }

        [Test, Order(3), Category("TC_008")]
        [Description("TC_008_SidebarMenuVisible")]
        public void SidebarMenuVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsSidebarMenuDisplayed(), "Sidebar should be visible.");
        }

        [Test, Order(4), Category("TC_009")]
        [Description("TC_009_AdminMenuVisible")]
        public void AdminMenuVisibleTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsAdminMenuDisplayed(), "Admin menu should be visible.");
        }

        [Test, Order(5), Category("TC_010")]
        [Description("TC_010_LogoutRedirectsToLogin")]
        public void LogoutRedirectsToLoginTest()
        {
            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.ClickLogout();
            Assert.IsTrue(driver.Url.Contains("login"), "Should redirect to login after logout.");
        }
    }
}
