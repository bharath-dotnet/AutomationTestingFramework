using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // ─── Locators ─────────────────────────────────────────────────────────────
        private By usernameField = By.Name("username");
        private By passwordField = By.Name("password");
        private By loginButton = By.XPath("//button[@type='submit']");
        private By errorMessage = By.XPath("//*[contains(@class,'oxd-alert-content-text')]");
        private By errorRequired = By.XPath("//*[contains(@class,'oxd-input-field-error-message')]");
        private By loginHeader = By.XPath("//h5[contains(text(),'Login')]");

        // ─── Actions ──────────────────────────────────────────────────────────────
        public void EnterUsername(string username)
        {
            EnterText(usernameField, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordField, password);
        }

        public void ClickLogin()
        {
            Click(loginButton);
        }

        public bool IsLoginPageDisplayed()
        {
            return IsElementDisplayed(loginHeader);
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(errorMessage) || IsElementDisplayed(errorRequired);
        }

        public string GetErrorMessageText()
        {
            if (IsElementDisplayed(errorMessage))
                return GetElementText(errorMessage);
            return GetElementText(errorRequired);
        }
    }
}
