using AutomationFramework.Base;
using AutomationFramework.Pages;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(3)]
    public class ProfileTests : BaseTest
    {
        [SetUp]
        public void ProfileSetUp()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));
            ProfilePage profile = new ProfilePage(driver);
            profile.NavigateToMyInfo();
        }

        [Test, Order(1), Category("TC_011")]
        [Description("TC_011_ProfilePageLoaded")]
        public void ProfilePageLoadedTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsProfilePageLoaded(), "Profile page should be loaded.");
        }

        [Test, Order(2), Category("TC_012")]
        [Description("TC_012_ProfileUrlContains")]
        public void ProfileUrlTest()
        {
            Assert.IsTrue(driver.Url.Contains("pim"), "URL should contain 'pim'.");
        }

        [Test, Order(3), Category("TC_013")]
        [Description("TC_013_FirstNameFieldVisible")]
        public void FirstNameFieldVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsFirstNameFieldDisplayed(), "First name field should be visible.");
        }

        [Test, Order(4), Category("TC_014")]
        [Description("TC_014_LastNameFieldVisible")]
        public void LastNameFieldVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsLastNameFieldDisplayed(), "Last name field should be visible.");
        }

        [Test, Order(5), Category("TC_015")]
        [Description("TC_015_SaveButtonVisible")]
        public void SaveButtonVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsSaveButtonDisplayed(), "Save button should be visible.");
        }
    }
}
