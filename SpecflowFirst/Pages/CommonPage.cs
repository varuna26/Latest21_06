using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;

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

        public string newWindowFrame = "rw";
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

        //IWebElement expandBarArrow => _webDriver.FindElement(By.ClassName("rdExpand"));
        IWebElement advanced_button => _webDriver.FindElement(By.Id("details-button"));
        IWebElement proceed_partialLink => _webDriver.FindElement(By.PartialLinkText("Proceed"));

        IWebElement permittingIcon => _webDriver.FindElement(By.Id("divIconPermit"));

        IWebElement landManagementIcon => _webDriver.FindElement(By.Id("divIconGeo"));

        By expandBarArrow => By.ClassName("rdExpand");

        By collapseBarArrow => By.ClassName("rdCollapse");

        public void NavigatetoUrl()
        {
            _webDriver.Manage().Window.Maximize();
            string trakitUrl = Settings.Default.TrakitAppUrl;
            _webDriver.Navigate().GoToUrl(trakitUrl);

            advanced_button.Click();
            proceed_partialLink.Click();

            //_driverHelper.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //_driverHelper.webDriver.FindElement(By.Id("details-button")).Click();
            //_driverHelper.webDriver.FindElement(By.PartialLinkText("Proceed")).Click();
        }

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
                //SwitchToFrame("FRMPERMIT");
                PermittingPage permittingPage = new PermittingPage(_webDriver);
                headerElement = permittingPage.ReturnHeaderElement();
                pageTitle = headerElement.FindElement(By.TagName("h1")).Text;
            }
            if (moduleName.Replace(" ", "").Contains("LandManagement"))
            {
                //SwitchToFrame("FRMLAND");
                LandManagementPage landManagementPage = new LandManagementPage(_webDriver);
                headerElement = landManagementPage.ReturnHeaderElement();
                pageTitle = headerElement.FindElement(By.TagName("h1")).Text;
            }
            return pageTitle;
        }

        //public IWebElement ScrollIntoView_Center(IWebElement element)//, bool top = true)
        //{
        //    IWebElement output = ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center', inline: 'center'}); return arguments[0];") as IWebElement; //attempt for middle
        //    Thread.Sleep(100);
        //    return output;
        //}

        //public void ExpandBar(IWebElement bar)
        //{
        //    try
        //    {
        //        //Actions actions = new Actions(_webDriver);
        //        //actions.MoveToElement(bar).DoubleClick(bar).Perform();
        //        //((IJavaScriptExecutor)_webDriver).ExecuteScript("scroll(500,0)");
        //        Thread.Sleep(5000);
        //        ((IJavaScriptExecutor)_webDriver).ExecuteScript("scroll(700,0)");
        //        Thread.Sleep(5000);
        //        IWebElement arrow = bar.FindElement(By.TagName("a"));
        //        Thread.Sleep(10000);
        //        //Scroll(500, 0);
        //        //Thread.Sleep(10000);
        //        Actions().MoveToElement(arrow).Click(arrow).Perform();
        //        Thread.Sleep(10000);
        //    }
        //    catch(Exception ex)
        //    {
        //        //try
        //        //{
        //        //    Wait(driver, 3).Until(ExpectedConditions.ElementToBeClickable(bar.FindElement(collapseBarArrow)));
        //        //}
        //        //catch
        //        //{
        //        //    throw new Exception("Failed to get the collapse state of bar located " + barLocator.ToString());
        //        //}
        //    }
        //}

        public void Scroll(int horizontal, int vertical)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("scroll(arguments[0], arguments[1])", horizontal, vertical);
        }

        public Actions Actions()
        {
            return new Actions(_webDriver);
        }

        //public static void ScrollToElement(IWebDriver driver, IWebElement element, int offset_y = -200, bool scroll_horizontal = false, int offset_x = -500)
        //{
        //    //Wait(driver).Until(d => element.Enabled);

        //    if (scroll_horizontal)
        //        ((IJavaScriptExecutor)driver).ExecuteScript("var rect = arguments[0].getBoundingClientRect(); window.scrollBy(rect.left + arguments[1], rect.top + arguments[2]);", element, offset_x, offset_y);
        //    else
        //        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, arguments[0].getBoundingClientRect().top + arguments[1]);", element, offset_y);
        //}

        public void SwitchToFrame(string frameName)
        {
            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame(frameName);
        }

        public void SwitchToFrame(int frameId)
        {
            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame(frameId);
        }

        public void ExecuteScript(string script)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
        }

        public void ClickElement(IWebElement button)
        {
            button.Click();
        }

        public void EnterText(IWebElement textElement, string text)
        {
            textElement.SendKeys(text);
        }

        public void OpenWindow(string newTabHandle)
        {
            _webDriver.SwitchTo().Window(newTabHandle); 
        }

        public void HoverToElement(IWebElement webElement)
        {
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(webElement).Build().Perform();
            Thread.Sleep(5000);
        }

        public void ClickLeftPanelIcons(string moduleName)
        {
            if (moduleName.Contains(Convert.ToString(ModuleEnum.Permitting)))
            {
                Thread.Sleep(1000);
                permittingIcon.Click();
                Thread.Sleep(1000);
                SwitchToFrame(Convert.ToString(FrameNameEnum.FRMPERMIT));
            }
            else if (moduleName.Replace(" ", "").Contains(Convert.ToString(ModuleEnum.LandManagement)))
            {
                landManagementIcon.Click();
                SwitchToFrame(Convert.ToString(FrameNameEnum.FRMLAND));
            }
            else if (moduleName.Contains(Convert.ToString(ModuleEnum.Workspace)))
            {
                // click that icon
            }
        }

        public void ScrollToElement(IWebDriver driver, IWebElement element, int offset_y = -200, bool scroll_horizontal = false, int offset_x = -500)
        {
            Wait(driver).Until(d => element.Enabled);

            if (scroll_horizontal)
                ((IJavaScriptExecutor)driver).ExecuteScript("var rect = arguments[0].getBoundingClientRect(); window.scrollBy(rect.left + arguments[1], rect.top + arguments[2]);", element, offset_x, offset_y);
            else
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, arguments[0].getBoundingClientRect().top + arguments[1]);", element, offset_y);
        }

        public static IWebElement ScrollIntoView(IWebDriver driver, By locator, bool top = true)
        {
            IWebElement output = ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollIntoView({top.ToString().ToLower()}); return arguments[0];", Wait(driver).Until(ExpectedConditions.ElementExists(locator))) as IWebElement;
            Thread.Sleep(100);
            return output;
        }

        public static WebDriverWait Wait(IWebDriver driver, double seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(InvalidOperationException), typeof(NoSuchElementException), typeof(NullReferenceException));
            return wait;
        }

        public void ExpandBar(By barLocator=null)
        {
            IWebElement bar = ScrollIntoView_Center(barLocator);
            try
            {
                if (bar.FindElements(expandBarArrow).Count != 0)
                {
                    IWebElement arrow = bar.FindElement(expandBarArrow);
                    arrow.Click();
                }
                else if(bar.FindElements(collapseBarArrow).Count != 0)
                {
                    // dont do anything
                }
                else
                {
                    // Error
                }

                //ScrollToElement(_webDriver, arrow);
                //Actions().MoveToElement(arrow).Click().Perform();
                //Wait(_webDriver).Until(ExpectedConditions.ElementToBeClickable(bar.FindElement(collapseBarArrow)));
            }
            catch
            {
                try
                {
                    Wait(_webDriver, 3).Until(ExpectedConditions.ElementToBeClickable(bar.FindElement(collapseBarArrow)));
                }
                catch
                {
                    throw new Exception("Failed to get the collapse state of bar located " + barLocator.ToString());
                }
            }
        }

        public IWebElement ScrollIntoView_Center(By element)//, bool top = true)
        {
            //return ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollIntoView({top.ToString().ToLower()}); return arguments[0];", Wait(driver).Until(ExpectedConditions.ElementIsVisible(element))) as IWebElement; //bottom or top
            IWebElement output = ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center', inline: 'center'}); return arguments[0];", Wait(_webDriver).Until(ExpectedConditions.ElementExists(element))) as IWebElement; //attempt for middle
            return output;
        }
    }
}
