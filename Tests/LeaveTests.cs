using AutomationFramework.Base;
using AutomationFramework.Pages;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(5)]
    public class LeaveTests : BaseTest
    {
        [SetUp]
        public void LeaveSetUp()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToMyLeave();
        }

        [Test, Order(1), Category("TC_021")]
        [Description("TC_021_MyLeavePageLoads")]
        public void MyLeavePageLoadsTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.IsMyLeavePageLoaded(), "My Leave page should be loaded.");
        }

        [Test, Order(2), Category("TC_022")]
        [Description("TC_022_MyLeaveUrlContains")]
        public void MyLeaveUrlTest()
        {
            Assert.IsTrue(driver.Url.Contains("leave"), "URL should contain 'leave'.");
        }

        [Test, Order(3), Category("TC_023")]
        [Description("TC_023_LeaveTableDisplayed")]
        public void LeaveTableDisplayedTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.IsLeaveTableDisplayed(), "Leave table should be displayed.");
        }

        [Test, Order(4), Category("TC_024")]
        [Description("TC_024_ApplyLeavePageLoads")]
        public void ApplyLeavePageLoadsTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(leave.IsApplyLeavePageLoaded(), "Apply Leave page should be loaded.");
        }

        [Test, Order(5), Category("TC_025")]
        [Description("TC_025_ApplyLeaveUrlContains")]
        public void ApplyLeaveUrlTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(driver.Url.Contains("applyLeave"), "URL should contain 'applyLeave'.");
        }
    }
}
