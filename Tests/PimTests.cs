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

        [Test, Order(1), Category("TC_045")]
        [Description("TC_045_EmployeeListPageLoads")]
        public void EmployeeListPageLoadsTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsEmployeeListPageLoaded(),
                "Employee List page should be loaded.");
        }

        [Test, Order(2), Category("TC_046")]
        [Description("TC_046_EmployeeListUrlContains")]
        public void EmployeeListUrlTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.GetCurrentUrl().Contains("pim"),
                "URL should contain 'pim'.");
        }

        [Test, Order(3), Category("TC_047")]
        [Description("TC_047_EmployeeTableDisplayed")]
        public void EmployeeTableDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsEmployeeTableDisplayed(),
                "Employee table should be displayed on Employee List page.");
        }

        [Test, Order(4), Category("TC_048")]
        [Description("TC_048_SearchButtonDisplayed")]
        public void SearchButtonDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsSearchButtonDisplayed(),
                "Search button should be visible on Employee List page.");
        }

        [Test, Order(5), Category("TC_049")]
        [Description("TC_049_AddButtonDisplayed")]
        public void AddButtonDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            Assert.IsTrue(pim.IsAddButtonDisplayed(),
                "Add button should be visible on Employee List page.");
        }

        [Test, Order(6), Category("TC_050")]
        [Description("TC_050_AddEmployeePageLoads")]
        public void AddEmployeePageLoadsTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.IsAddEmployeePageLoaded(),
                "Add Employee page should be loaded.");
        }

        [Test, Order(7), Category("TC_051")]
        [Description("TC_051_AddEmployeeUrlContains")]
        public void AddEmployeeUrlTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.GetCurrentUrl().Contains("addEmployee"),
                "URL should contain 'addEmployee'.");
        }

        [Test, Order(8), Category("TC_052")]
        [Description("TC_052_AddEmployeeFormDisplayed")]
        public void AddEmployeeFormDisplayedTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.IsAddEmployeeFormDisplayed(),
                "Add Employee form should be displayed.");
        }

        [Test, Order(9), Category("TC_053")]
        [Description("TC_053_FirstNameFieldVisible")]
        public void FirstNameFieldVisibleTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.IsFirstNameFieldDisplayed(),
                "First Name field should be visible on Add Employee page.");
        }

        [Test, Order(10), Category("TC_054")]
        [Description("TC_054_LastNameFieldVisible")]
        public void LastNameFieldVisibleTest()
        {
            PimPage pim = new PimPage(driver);
            pim.NavigateToAddEmployee();
            Assert.IsTrue(pim.IsLastNameFieldDisplayed(),
                "Last Name field should be visible on Add Employee page.");
        }
    }
}
