using OpenQA.Selenium;
using SpecflowFirst.PageObjects;

namespace SpecflowFirst.Pages
{
    public class LoginPage
    {
        private IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement login_username =>_webDriver.FindElement(By.Id("txtUID"));
        IWebElement login_password =>_webDriver.FindElement(By.Id("txtPWD"));
        IWebElement login_rememberMe => _webDriver.FindElement(By.Id("chkRememberMe"));
        IWebElement login_button => _webDriver.FindElement(By.Id("btnSignIn"));
        IWebElement login_error => _webDriver.FindElement(By.Id("lblLoginMsg"));
        IWebElement logout_error => _webDriver.FindElement(By.Id("lblError"));
        IWebElement logout_logBackInButton => _webDriver.FindElement(By.XPath("//span[@id=\"lblError\"]/a"));
    

        public void EnterUsernameToLogin(string userName)
        {
            login_username.EnterText(userName);
        }

        public void EnterPasswordToLogin(string password)
        {
            login_password.EnterText(password);
        }

        public void ClickLogin()
        {
            login_button.ButtonClick();
            //return new HomePage(_webDriver);
        }
    }
}
