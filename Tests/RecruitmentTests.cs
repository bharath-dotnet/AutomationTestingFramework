using AutomationFramework.Base;
using AutomationFramework.Pages;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(4)]
    public class RecruitmentTests : BaseTest
    {
        [SetUp]
        public void RecruitmentSetUp()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));

            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.NavigateToVacancies();
        }

        [Test, Order(1), Category("TC_025")]
        [Description("TC_025_VacanciesPageLoads")]
        public void VacanciesPageLoadsTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            Assert.IsTrue(recruitment.IsVacanciesPageLoaded(),
                "Vacancies page should be loaded — URL should contain 'recruitment'.");
        }

        [Test, Order(2), Category("TC_026")]
        [Description("TC_026_VacanciesUrlContains")]
        public void VacanciesUrlTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            string url = recruitment.GetCurrentUrl();
            Assert.IsTrue(url.Contains("recruitment"),
                $"Expected recruitment URL but got: '{url}'");
        }

        [Test, Order(3), Category("TC_027")]
        [Description("TC_027_VacancyTableDisplayed")]
        public void VacancyTableDisplayedTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            Assert.IsTrue(recruitment.IsVacancyTableDisplayed(),
                "Vacancy table should be displayed on vacancies page.");
        }

        [Test, Order(4), Category("TC_028")]
        [Description("TC_028_AddVacancyPageLoads")]
        public void AddVacancyPageLoadsTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            Assert.IsTrue(recruitment.IsAddVacancyPageLoaded(),
                "Add Vacancy form should be visible after clicking Add.");
        }

        [Test, Order(5), Category("TC_029")]
        [Description("TC_029_VacancyNameFieldVisible")]
        public void VacancyNameFieldVisibleTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            Assert.IsTrue(recruitment.IsVacancyNameFieldDisplayed(),
                "Vacancy Name field should be visible on Add Vacancy page.");
        }

        [Test, Order(6), Category("TC_030")]
        [Description("TC_030_JobTitleDropdownVisible")]
        public void JobTitleDropdownVisibleTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            Assert.IsTrue(recruitment.IsJobTitleDropdownDisplayed(),
                "Job Title dropdown should be visible on Add Vacancy page.");
        }

        [Test, Order(7), Category("TC_031")]
        [Description("TC_031_SaveButtonVisible")]
        public void SaveButtonVisibleTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            Assert.IsTrue(recruitment.IsSaveButtonDisplayed(),
                "Save button should be visible on Add Vacancy page.");
        }

        [Test, Order(8), Category("TC_032")]
        [Description("TC_032_CancelButtonVisible")]
        public void CancelButtonVisibleTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            Assert.IsTrue(recruitment.IsCancelButtonDisplayed(),
                "Cancel button should be visible on Add Vacancy page.");
        }

        [Test, Order(9), Category("TC_033")]
        [Description("TC_033_SaveWithoutFieldsShowsError")]
        public void SaveWithoutFieldsShowsErrorTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            recruitment.ClickSave();
            Assert.IsTrue(recruitment.IsErrorMessageDisplayed(),
                "Error message should appear when saving without filling required fields.");
        }

        [Test, Order(10), Category("TC_034")]
        [Description("TC_034_CancelRedirectsToVacancies")]
        public void CancelRedirectsToVacanciesTest()
        {
            RecruitmentPage recruitment = new RecruitmentPage(driver);
            recruitment.ClickAddVacancy();
            recruitment.ClickCancel();
            Assert.IsTrue(recruitment.IsVacanciesPageLoaded(),
                "Cancel should redirect back to Vacancies page.");
        }
    }
}
