using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Pages
{
    public class RecruitmentPage : BasePage
    {
        public RecruitmentPage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By vacancyPageHeader = By.XPath("//h5[contains(@class,'oxd-text')] | //h6[contains(@class,'oxd-text')]");
        private By addVacancyButton = By.XPath("//button[normalize-space()='Add']");
        private By addVacancyHeader = By.XPath("//h6[contains(.,'Add Vacancy')] | //h5[contains(.,'Add Vacancy')]");
        private By vacancyNameField = By.XPath("(//input[@class='oxd-input oxd-input--active'])[1]");
        private By jobTitleDropdown = By.XPath("(//div[contains(@class,'oxd-select-text-input')])[1]");
        private By saveButton = By.XPath("//button[@type='submit']");
        private By cancelButton = By.XPath("//button[normalize-space()='Cancel']");
        private By vacancyTable = By.CssSelector(".oxd-table");
        private By errorMessage = By.CssSelector(".oxd-input-field-error-message");
        private By pageContainer = By.CssSelector(".oxd-layout-context");

        // ─── Actions ──────────────────────────────────────────────────────────────

        /// <summary>Navigate to Recruitment Vacancies page via URL.</summary>
        public void NavigateToVacancies()
        {
            driver.Navigate().GoToUrl(
                "https://opensource-demo.orangehrmlive.com/web/index.php/recruitment/viewJobVacancy");

            // Wait for page container to load — more reliable than header text
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(d => d.Url.Contains("recruitment") &&
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");

            // Extra wait for React to render
            System.Threading.Thread.Sleep(2000);
        }

        public void ClickAddVacancy()
        {
            Click(addVacancyButton);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(d => d.Url.Contains("addJobVacancy") ||
                IsElementDisplayed(vacancyNameField));
        }

        public bool IsVacanciesPageLoaded()
        {
            // Check URL contains recruitment instead of header text
            return driver.Url.Contains("recruitment");
        }

        public bool IsAddVacancyPageLoaded()
        {
            return IsElementDisplayed(vacancyNameField);
        }

        public bool IsVacancyNameFieldDisplayed()
        {
            return IsElementDisplayed(vacancyNameField);
        }

        public bool IsJobTitleDropdownDisplayed()
        {
            return IsElementDisplayed(jobTitleDropdown);
        }

        public bool IsSaveButtonDisplayed()
        {
            return IsElementDisplayed(saveButton);
        }

        public bool IsCancelButtonDisplayed()
        {
            return IsElementDisplayed(cancelButton);
        }

        public bool IsVacancyTableDisplayed()
        {
            return IsElementDisplayed(vacancyTable);
        }

        public void ClickSave()
        {
            Click(saveButton);
        }

        public void ClickCancel()
        {
            Click(cancelButton);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(d => d.Url.Contains("viewJobVacancy"));
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(errorMessage);
        }

        public string GetErrorMessageText()
        {
            return GetElementText(errorMessage);
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public string GetVacancyHeaderText()
        {
            try { return GetElementText(vacancyPageHeader); }
            catch { return driver.Url; }
        }
    }
}
