using AutomationFramework.Base;
using AutomationFramework.Pages;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(6)]
    public class PimTests : BaseTest
    {
        [SetUp]
        public void PimSetUp()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));
            PimPage pim = new PimPage(driver);
            pim.NavigateToEmployeeList();
        }

        [Test, Order(1), Category("TC_026")]
        [Description("TC_026_EmployeeListPageLoads")]
        public void EmployeeListPageLoadsTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsEmployeeListPageLoaded(), "Employee List page should be loaded.");
        }

        [Test, Order(2), Category("TC_027")]
        [Description("TC_027_EmployeeListUrlContains")]
        public void EmployeeListUrlTest()
        {
            Assert.IsTrue(driver.Url.Contains("pim"), "URL should contain 'pim'.");
        }

        [Test, Order(3), Category("TC_028")]
        [Description("TC_028_EmployeeTableDisplayed")]
        public void EmployeeTableDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsEmployeeTableDisplayed(), "Employee table should be displayed.");
        }

        [Test, Order(4), Category("TC_029")]
        [Description("TC_029_AddButtonDisplayed")]
        public void AddButtonDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsAddButtonDisplayed(), "Add button should be visible.");
        }

        [Test, Order(5), Category("TC_030")]
        [Description("TC_030_AddEmployeePageLoads")]
        public void AddEmployeePageLoadsTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.IsAddEmployeePageLoaded(), "Add Employee page should be loaded.");
        }
    }
}
