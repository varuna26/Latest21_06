using OpenQA.Selenium;
using SpecflowFirst.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Steps
{
    [Binding]
    public class LoginSteps : DriverHelper
    {
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        CommonPage genericPage;
        LoginPage loginPage;
        public LoginSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            loginPage = new LoginPage(driverHelper.webDriver);
            genericPage = new CommonPage(driverHelper.webDriver);
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

            //BasePage<LoginPage>.Page.EnterUsernameToLogin(p0);
            //BasePage<LoginPage>.EnterUsernameToLogin(p0);
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
            //string pageTitle = _webDriver.Title;
            //Assert.That(pageTitle, Does.Contain(""));
        }

        [Then(@"I should be able to login successfully")]
        public void ThenIShouldBeAbleToLoginSuccessfully()
        {
            //Assert.That(pageTitle, Does.Contain(""));
            //genericPage.basePage.As<HomePage>().NewMethod();
        }

        [Given(@"The User navigates to the website ""(.*)""")]
        public void GivenTheUserNavigatesToTheWebsite(string p0)
        {

        }

        [When(@"The User tries logging in with Username and Password")]
        public void WhenTheUserTriesLoggingInWithUsernameAndPassword(Table table)
        {
           
        }

        [Then(@"The User should be able to login successfully")]
        public void ThenTheUserShouldBeAbleToLoginSuccessfully()
        {

        }



        [When(@"The User tries logging in with invalid UserName and Password")]
        public void WhenTheUserTriesLoggingInWithInvalidUserNameAndPassword(Table table)
        {

        }

        [Then(@"The User should not be able to login")]
        public void ThenTheUserShouldNotBeAbleToLogin()
        {
           
        }

    }
}
