using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Pages
{
   public class CommonPage
    {
        //private ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        public CommonPage(IWebDriver webDriver)
        {
            //_scenarioContext = scenarioContext;
            _webDriver = webDriver;
        }

        //private BasePage _basePage;

        //public BasePage basePage
        //{
        //    get
        //    {
        //        return _basePage;
        //    }
        //    set
        //    {
        //        _scenarioContext["class"] = value;
        //        _basePage = (BasePage)_scenarioContext["class"];
        //    }
        //}

        public WorkspacePage Login(string userName, string password)
        {
            WorkspacePage workspacePage = new WorkspacePage(_webDriver);
            LoginPage loginPage = new LoginPage(_webDriver);
            loginPage.EnterUsernameToLogin(userName);
            loginPage.EnterPasswordToLogin(password);
            loginPage.ClickLogin();
            return workspacePage;
        }

        public string getPageTitle(string moduleName)
        {
            string pageTitle = "";
            IWebElement headerElement;
            if (moduleName.Contains("Permitting"))
            {
                SwitchToFrame("FRMPERMIT");
                PermittingPage permittingPage = new PermittingPage(_webDriver);
                headerElement = permittingPage.ReturnHeaderElement();
                pageTitle = headerElement.FindElement(By.TagName("h1")).Text;
            }
            if (moduleName.Replace(" ", "").Contains("LandManagement"))
            {
                SwitchToFrame("FRMLAND");
                LandManagementPage landManagementPage = new LandManagementPage(_webDriver);
                headerElement = landManagementPage.ReturnHeaderElement();
                pageTitle = headerElement.FindElement(By.TagName("h1")).Text;
            }
            return pageTitle;
        }

        public static IWebElement ScrollIntoView_Center(IWebDriver driver, By element)//, bool top = true)
        {
            IWebElement output = ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center', inline: 'center'}); return arguments[0];") as IWebElement; //attempt for middle
            Thread.Sleep(100);
            return output;
        }

        public static void ExpandBar(IWebDriver driver, By barLocator)
        {
            IWebElement webElement = CommonPage.ScrollIntoView_Center(driver, barLocator);
            try
            {

            }
            catch
            {
                throw new Exception("Failed to get the collapse state of bar located " + barLocator.ToString());
            }
        }
            
        public void SwitchToFrame(string frameName)
        {
            _webDriver.SwitchTo().Frame(frameName);
        }
    }
}
