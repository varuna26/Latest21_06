using OpenQA.Selenium;
using SpecflowFirst.PageObjects;
using System;
using System.Linq;

namespace SpecflowFirst.Pages
{
    public class LoginPage : CommonPage
    {
        private IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement btnAdvanced => _webDriver.FindElement(By.Id("details-button"));
        IWebElement partialLinkProceed => _webDriver.FindElement(By.PartialLinkText("Proceed"));
        IWebElement txtUsername => _webDriver.FindElement(By.Id("txtUID"));
        IWebElement txtPassword => _webDriver.FindElement(By.Id("txtPWD"));
        IWebElement chkRememberMe => _webDriver.FindElement(By.Id("chkRememberMe"));
        IWebElement btnLogin => _webDriver.FindElement(By.Id("btnSignIn"));
        IWebElement errorMsgLogin => _webDriver.FindElement(By.Id("lblLoginMsg"));
        IWebElement errorMsgLogout => _webDriver.FindElement(By.Id("lblError"));
        IWebElement btnLogBackIn => _webDriver.FindElement(By.XPath("//span[@id=\"lblError\"]/a"));

        /// <summary>
        /// Enter User Name on Login Page
        /// </summary>
        /// <param name="userName"></param>
        public void EnterUsernameToLogin(string userName)
        {
            txtUsername.EnterText(userName);
        }

        /// <summary>
        /// Enter Password on Login Page
        /// </summary>
        /// <param name="password"></param>
        public void EnterPasswordToLogin(string password)
        {
            txtPassword.EnterText(password);
        }

        /// <summary>
        /// Click Login Button
        /// </summary>
        public void ClickLogin()
        {
            ClickElement(btnLogin);
        }

        /// <summary>
        /// Application VPN bypass to open CommDev login page
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void AppLogin(string userName, string password)
        {
            _webDriver.Manage().Window.Maximize();
            string trakitUrl = Settings.Default.TrakitAppUrl;
            _webDriver.Navigate().GoToUrl(trakitUrl);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ClickElement(btnAdvanced);
            ClickElement(partialLinkProceed);
            //btnAdvanced.Click();
            //partialLinkProceed.Click();

            Login(userName, password);
        }

        /// <summary>
        /// Login to the application
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Login(string userName, string password)
        {
            //WorkspacePage workspacePage = new WorkspacePage(_webDriver);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            EnterUsernameToLogin(userName);
            EnterPasswordToLogin(password);
            ClickLogin();
        }

        /// <summary>
        /// Logout of the application
        /// </summary>
        public void LogOut()
        {
            By userNameLocator = By.ClassName("rmLast");
            IWebElement lblUserName = _webDriver.FindElement(By.ClassName("rmLast"));
            HoverElement(userNameLocator, lblUserName);

            IWebElement itemLogout = lblUserName.FindElements(By.ClassName("rmLast")).First();
            {
                if (string.Compare("Logout", itemLogout.Text, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    itemLogout.Click();
                }
            }
        }
    }
}
