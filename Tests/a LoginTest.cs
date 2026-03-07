using AutomationFramework.Base;
using AutomationFramework.Pages;
using AutomationFramework.Utilities;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    [TestFixture]
    [Order(1)]
    public class LoginTests : BaseTest
    {
        [Test, Order(1), Category("TC_001")]
        [Description("TC_001_ValidLogin")]
        public void ValidLoginTest()
        {
            LoginPage login = new LoginPage(driver);
            var data = TestDataReader.GetLoginData("ValidUser");
            login.EnterUsername(data.Username);
            login.EnterPassword(data.Password);
            login.ClickLogin();

            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.IsDashboardLoaded(),
                "Dashboard should load after valid login.");
        }

        [Test, Order(2), Category("TC_002")]
        [Description("TC_002_InvalidUsername")]
        public void InvalidUsernameTest()
        {
            LoginPage login = new LoginPage(driver);
            var data = TestDataReader.GetLoginData("InvalidUser");
            login.EnterUsername(data.Username);
            login.EnterPassword(data.Password);
            login.ClickLogin();

            Assert.IsTrue(login.IsErrorMessageDisplayed(),
                "Error message should appear for invalid username.");
        }

        [Test, Order(3), Category("TC_003")]
        [Description("TC_003_InvalidPassword")]
        public void InvalidPasswordTest()
        {
            LoginPage login = new LoginPage(driver);
            var data = TestDataReader.GetLoginData("InvalidPassword");
            login.EnterUsername(data.Username);
            login.EnterPassword(data.Password);
            login.ClickLogin();

            Assert.IsTrue(login.IsErrorMessageDisplayed(),
                "Error message should appear for invalid password.");
        }

        [Test, Order(4), Category("TC_004")]
        [Description("TC_004_EmptyFields")]
        public void EmptyFieldsTest()
        {
            LoginPage login = new LoginPage(driver);
            login.ClickLogin();

            Assert.IsTrue(login.IsErrorMessageDisplayed(),
                "Error message should appear for empty fields.");
        }

        [Test, Order(5), Category("TC_005")]
        [Description("TC_005_SpecialCharacters")]
        public void SpecialCharacterLoginTest()
        {
            LoginPage login = new LoginPage(driver);
            var data = TestDataReader.GetLoginData("SpecialCharacters");
            login.EnterUsername(data.Username);
            login.EnterPassword(data.Password);
            login.ClickLogin();

            Assert.IsTrue(login.IsErrorMessageDisplayed(),
                "Error message should appear for special characters.");
        }
    }
}
