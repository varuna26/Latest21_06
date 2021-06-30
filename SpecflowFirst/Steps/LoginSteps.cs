using OpenQA.Selenium;
using SpecflowFirst.Pages;
using SpecflowFramework.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        CommonPage commonPage;
        LoginPage loginPage;
        public LoginSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            loginPage = new LoginPage(driverHelper.webDriver);
            commonPage = new CommonPage(driverHelper.webDriver);
        }

        [Given(@"I am on community dev login page")]
        public void GivenIAmOnCommunityDevLoginPage()
        {
            _driverHelper.webDriver.Manage().Window.Maximize();
            string trakitUrl = Settings.Default.TrakitAppUrl;
            _driverHelper.webDriver.Navigate().GoToUrl(trakitUrl);
            _driverHelper.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driverHelper.webDriver.FindElement(By.Id("details-button")).Click();
            _driverHelper.webDriver.FindElement(By.PartialLinkText("Proceed")).Click();
        }

        [When(@"I Enter ""(.*)"" in Username")]
        public void WhenIEnterInUsername(string userName)
        {
            loginPage.EnterUsernameToLogin(userName);
        }

        [When(@"I Enter ""(.*)"" in Password")]
        public void WhenIEnterInPassword(string passWord)
        {
            loginPage.EnterPasswordToLogin(passWord);
        }

        [When(@"I Click Login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should be able to login successfully")]
        public void ThenIShouldBeAbleToLoginSuccessfully()
        {
            
        }
    }
}
