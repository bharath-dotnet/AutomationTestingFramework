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
            // BaseTest.Setup() already opened browser and navigated to OrangeHRM login
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("Admin");
            login.EnterPassword("admin123");
            login.ClickLogin();

            // Wait for dashboard
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.Url.Contains("dashboard"));

            // Navigate directly to My Info page via URL
            ProfilePage profile = new ProfilePage(driver);
            profile.NavigateToMyInfo();
        }

        [Test, Order(1), Category("TC_015")]
        [Description("TC_015_ProfilePageLoaded")]
        public void ProfilePageLoadedTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsProfilePageLoaded(),
                "Personal Details header should be visible on profile page.");
        }

        [Test, Order(2), Category("TC_016")]
        [Description("TC_016_ProfileHeaderText")]
        public void ProfileHeaderTextTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            string header = profile.GetProfileHeaderText();
            Assert.IsTrue(header.Contains("Personal Details"),
                $"Expected 'Personal Details' but got: '{header}'");
        }

        [Test, Order(3), Category("TC_017")]
        [Description("TC_017_ProfileUrlContains")]
        public void ProfileUrlTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            string url = profile.GetCurrentUrl();
            Assert.IsTrue(url.Contains("pim") || url.Contains("viewMyDetails"),
                $"Expected profile URL but got: '{url}'");
        }

        [Test, Order(4), Category("TC_018")]
        [Description("TC_018_FirstNameFieldVisible")]
        public void FirstNameFieldVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsFirstNameFieldDisplayed(),
                "First name field should be visible on profile page.");
        }

        [Test, Order(5), Category("TC_019")]
        [Description("TC_019_LastNameFieldVisible")]
        public void LastNameFieldVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsLastNameFieldDisplayed(),
                "Last name field should be visible on profile page.");
        }

        [Test, Order(6), Category("TC_020")]
        [Description("TC_020_SaveButtonVisible")]
        public void SaveButtonVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsSaveButtonDisplayed(),
                "Save button should be visible on profile page.");
        }

        [Test, Order(7), Category("TC_021")]
        [Description("TC_021_PersonalDetailsTabVisible")]
        public void PersonalDetailsTabVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsPersonalDetailsTabDisplayed(),
                "Personal Details tab should be visible.");
        }

        [Test, Order(8), Category("TC_022")]
        [Description("TC_022_ContactDetailsTabVisible")]
        public void ContactDetailsTabVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsContactDetailsTabDisplayed(),
                "Contact Details tab should be visible.");
        }

        [Test, Order(9), Category("TC_023")]
        [Description("TC_023_EmergencyContactsTabVisible")]
        public void EmergencyContactsTabVisibleTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            Assert.IsTrue(profile.IsEmergencyTabDisplayed(),
                "Emergency Contacts tab should be visible.");
        }

        [Test, Order(10), Category("TC_024")]
        [Description("TC_024_ProfileLogoutRedirectsToLogin")]
        public void ProfileLogoutRedirectsToLoginTest()
        {
            ProfilePage profile = new ProfilePage(driver);
            profile.ClickLogout();
            Assert.IsTrue(driver.Url.Contains("login"),
                "Should redirect to login page after logout.");
        }
    }
}
