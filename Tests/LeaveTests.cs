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

        [Test, Order(1), Category("TC_035")]
        [Description("TC_035_MyLeavePageLoads")]
        public void MyLeavePageLoadsTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.IsMyLeavePageLoaded(),
                "My Leave page should be loaded.");
        }

        [Test, Order(2), Category("TC_036")]
        [Description("TC_036_MyLeaveUrlContains")]
        public void MyLeaveUrlTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.GetCurrentUrl().Contains("leave"),
                "URL should contain 'leave'.");
        }

        [Test, Order(3), Category("TC_037")]
        [Description("TC_037_LeaveTableDisplayed")]
        public void LeaveTableDisplayedTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.IsLeaveTableDisplayed(),
                "Leave table should be displayed on My Leave page.");
        }

        [Test, Order(4), Category("TC_038")]
        [Description("TC_038_ApplyLeavePageLoads")]
        public void ApplyLeavePageLoadsTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(leave.IsApplyLeavePageLoaded(),
                "Apply Leave page should be loaded.");
        }

        [Test, Order(5), Category("TC_039")]
        [Description("TC_039_ApplyLeaveUrlContains")]
        public void ApplyLeaveUrlTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(leave.GetCurrentUrl().Contains("applyLeave"),
                "URL should contain 'applyLeave'.");
        }

        [Test, Order(6), Category("TC_040")]
        [Description("TC_040_ApplyLeaveFormDisplayed")]
        public void ApplyLeaveFormDisplayedTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(leave.IsFormDisplayed(),
                "Apply Leave form should be displayed.");
        }

        [Test, Order(7), Category("TC_041")]
        [Description("TC_041_MyLeaveListUrlValid")]
        public void MyLeaveListUrlValidTest()
        {
            LeavePage leave = new LeavePage(driver);
            Assert.IsTrue(leave.GetCurrentUrl().Contains("viewMyLeaveList"),
                "URL should contain 'viewMyLeaveList'.");
        }

        [Test, Order(8), Category("TC_042")]
        [Description("TC_042_LeaveModuleAccessible")]
        public void LeaveModuleAccessibleTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToMyLeave();
            Assert.IsTrue(leave.IsMyLeavePageLoaded(),
                "Leave module should be accessible after login.");
        }

        [Test, Order(9), Category("TC_043")]
        [Description("TC_043_ApplyLeaveAccessible")]
        public void ApplyLeaveAccessibleTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToApplyLeave();
            Assert.IsTrue(leave.IsApplyLeavePageLoaded(),
                "Apply Leave page should be accessible.");
        }

        [Test, Order(10), Category("TC_044")]
        [Description("TC_044_LeaveTableVisible")]
        public void LeaveTableVisibleTest()
        {
            LeavePage leave = new LeavePage(driver);
            leave.NavigateToMyLeave();
            Assert.IsTrue(leave.IsLeaveTableDisplayed(),
                "Leave table should be visible on My Leave List page.");
        }
    }
}
