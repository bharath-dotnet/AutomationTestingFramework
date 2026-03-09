using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace AutomationFramework.Pages
{
    public class PimPage : BasePage
    {
        public PimPage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By employeeTable = By.CssSelector(".oxd-table");
        private By searchButton = By.XPath("//button[@type='submit']");
        private By addButton = By.XPath("//button[normalize-space()='Add']");
        private By addEmpHeader = By.XPath("//h6[contains(.,'Add Employee')]");
        private By firstNameField = By.XPath("//input[@name='firstName']");
        private By lastNameField = By.XPath("//input[@name='lastName']");
        private By pageForm = By.CssSelector(".oxd-form");
        private By errorMessage = By.CssSelector(".oxd-input-field-error-message");

        // ─── Navigation ───────────────────────────────────────────────────────────

        /// <summary>Navigate directly to Employee List page via URL.</summary>
        public void NavigateToEmployeeList()
        {
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            w.Until(d => d.Url.Contains("pim") &&
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
            System.Threading.Thread.Sleep(2000);
        }

        /// <summary>Navigate directly to Add Employee page via URL.</summary>
        public void NavigateToAddEmployee()
        {
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/pim/addEmployee");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            w.Until(d => d.Url.Contains("addEmployee") &&
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
            System.Threading.Thread.Sleep(2000);
        }

        // ─── Checks ───────────────────────────────────────────────────────────────

        public bool IsEmployeeListPageLoaded() => driver.Url.Contains("viewEmployeeList");
        public bool IsAddEmployeePageLoaded() => driver.Url.Contains("addEmployee");
        public string GetCurrentUrl() => driver.Url;

        public bool IsEmployeeTableDisplayed()
        {
            return IsElementDisplayed(employeeTable);
        }

        public bool IsSearchButtonDisplayed()
        {
            return IsElementDisplayed(searchButton);
        }

        public bool IsAddButtonDisplayed()
        {
            return IsElementDisplayed(addButton);
        }

        public bool IsAddEmployeeFormDisplayed()
        {
            return IsElementDisplayed(pageForm);
        }

        public bool IsFirstNameFieldDisplayed()
        {
            return IsElementDisplayed(firstNameField);
        }

        public bool IsLastNameFieldDisplayed()
        {
            return IsElementDisplayed(lastNameField);
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(errorMessage);
        }

        public void ClickAddButton()
        {
            Click(addButton);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(d => d.Url.Contains("addEmployee"));
        }
    }
}
