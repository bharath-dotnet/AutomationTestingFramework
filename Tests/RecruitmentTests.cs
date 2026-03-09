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

        [Test, Order(1), Category("TC_016")]
        [Description("TC_016_VacanciesPageLoads")]
        public void VacanciesPageLoadsTest()
        {
            RecruitmentPage r = new RecruitmentPage(driver);
            Assert.IsTrue(r.IsVacanciesPageLoaded(), "Vacancies page should be loaded.");
        }

        [Test, Order(2), Category("TC_017")]
        [Description("TC_017_VacanciesUrlContains")]
        public void VacanciesUrlTest()
        {
            Assert.IsTrue(driver.Url.Contains("recruitment"), "URL should contain 'recruitment'.");
        }

        [Test, Order(3), Category("TC_018")]
        [Description("TC_018_VacancyTableDisplayed")]
        public void VacancyTableDisplayedTest()
        {
            RecruitmentPage r = new RecruitmentPage(driver);
            Assert.IsTrue(r.IsVacancyTableDisplayed(), "Vacancy table should be displayed.");
        }

        [Test, Order(4), Category("TC_019")]
        [Description("TC_019_AddVacancyPageLoads")]
        public void AddVacancyPageLoadsTest()
        {
            RecruitmentPage r = new RecruitmentPage(driver);
            r.ClickAddVacancy();
            Assert.IsTrue(r.IsAddVacancyPageLoaded(), "Add Vacancy page should be loaded.");
        }

        [Test, Order(5), Category("TC_020")]
        [Description("TC_020_SaveWithoutFieldsShowsError")]
        public void SaveWithoutFieldsShowsErrorTest()
        {
            RecruitmentPage r = new RecruitmentPage(driver);
            r.ClickAddVacancy();
            r.ClickSave();
            Assert.IsTrue(r.IsErrorMessageDisplayed(), "Error message should appear.");
        }
    }
}
