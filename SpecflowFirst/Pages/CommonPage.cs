using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecflowFramework.Utilities;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SpecflowFirst.Pages
{
    public class CommonPage
    {
        //private ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        //LoginPage loginPage;
        public CommonPage(IWebDriver webDriver)
        {
            //_scenarioContext = scenarioContext;
            _webDriver = webDriver;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //loginPage = new LoginPage(webDriver);
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
        //IWebElement btnAdvanced => _webDriver.FindElement(By.Id("details-button"));
        //IWebElement partialLinkProceed => _webDriver.FindElement(By.PartialLinkText("Proceed"));

       public IWebElement lblIconPermitting => _webDriver.FindElement(By.Id("spanIconPermit"));

       public IWebElement iconPermitting => _webDriver.FindElement(By.Id("divIconPermit"));

       public IWebElement iconLandManagement => _webDriver.FindElement(By.Id("divIconGeo"));

        By expandBarArrow => By.ClassName("rdExpand");

        By collapseBarArrow => By.ClassName("rdCollapse");

        //public void AppLogin(string userName, string password)
        //{
        //    _webDriver.Manage().Window.Maximize();
        //    string trakitUrl = Settings.Default.TrakitAppUrl;
        //    _webDriver.Navigate().GoToUrl(trakitUrl);
        //    _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        //    btnAdvanced.Click();
        //    partialLinkProceed.Click();

        //    Login(userName, password);
        //}

        //public void Login(string userName, string password)
        //{
        //    WorkspacePage workspacePage = new WorkspacePage(_webDriver);
        //    //LoginPage loginPage = new LoginPage(_webDriver);
        //    loginPage.EnterUsernameToLogin(userName);
        //    loginPage.EnterPasswordToLogin(password);
        //    loginPage.ClickLogin();
        //    //return workspacePage;
        //}

        /// <summary>
        /// Return Page title, to be used in assertions, based on module names
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to scroll the bar horizontal and vertical
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void Scroll(int horizontal, int vertical)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("scroll(arguments[0], arguments[1])", horizontal, vertical);
        }

        /// <summary>
        /// Generic Actions class method for mouse actions
        /// </summary>
        /// <returns></returns>
        public Actions Actions()
        {
            return new Actions(_webDriver);
        }

        /// <summary>
        /// Scroll to a particular element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="offset_y"></param>
        /// <param name="scroll_horizontal"></param>
        /// <param name="offset_x"></param>
        public static void ScrollToElement(IWebDriver driver, IWebElement element, int offset_y = -200, bool scroll_horizontal = false, int offset_x = -500)
        {
            //Wait(driver).Until(d => element.Enabled);

            if (scroll_horizontal)
                ((IJavaScriptExecutor)driver).ExecuteScript("var rect = arguments[0].getBoundingClientRect(); window.scrollBy(rect.left + arguments[1], rect.top + arguments[2]);", element, offset_x, offset_y);
            else
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, arguments[0].getBoundingClientRect().top + arguments[1]);", element, offset_y);
        }

        /// <summary>
        /// Method to switch iframes based on Frame name
        /// </summary>
        /// <param name="frameName"></param>
        public void SwitchToFrame(string frameName)
        {
            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame(frameName);
        }

        /// <summary>
        /// Method to switch iframes based on frame id
        /// </summary>
        /// <param name="frameId"></param>
        public void SwitchToFrame(int frameId)
        {
            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame(frameId);
        }

        /// <summary>
        /// Generic method to execute any javascript command
        /// </summary>
        /// <param name="script"></param>
        public void ExecuteScript(string script)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
        }

        /// <summary>
        /// Method to click an element with Explicit Wait
        /// </summary>
        /// <param name="button"></param>
        public void ClickElement(IWebElement button)
        {
            WaitsHelper.WaitUntilClickable(_webDriver, button, TimeSpan.FromSeconds(20));
            button.Click();
        }

        /// <summary>
        /// Method for Webdriver SendKeys
        /// </summary>
        /// <param name="textElement"></param>
        /// <param name="text"></param>
        public void EnterText(IWebElement textElement, string text)
        {
            textElement.SendKeys(text);
        }

        /// <summary>
        /// Open a new popup
        /// </summary>
        /// <param name="newTabHandle"></param>
        public void OpenWindow(string newTabHandle)
        {
            _webDriver.SwitchTo().Window(newTabHandle);
        }

        /// <summary>
        /// Method to mouseover an element
        /// </summary>
        /// <param name="webElement"></param>
        public void HoverElement(By elementLocator, IWebElement webElement)
        {
            WaitsHelper.WaitUntilExists(_webDriver, elementLocator, TimeSpan.FromSeconds(10));
            Actions().MoveToElement(webElement).Build().Perform();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Generic method to click Panel icons on Workspace screen based on module name
        /// </summary>
        /// <param name="moduleName"></param>
        public void ClickLeftPanelIcons(string moduleName)
        {
            if (moduleName.Contains(Convert.ToString(ModuleEnum.Permitting)))
            {
                PermittingPage permittingPage = new PermittingPage(_webDriver);
                permittingPage.ClickPermittingIcon();
            }
            else if (moduleName.Replace(" ", "").Contains(Convert.ToString(ModuleEnum.LandManagement)))
            {
                iconLandManagement.Click();
                SwitchToFrame(Convert.ToString(FrameNameEnum.FRMLAND));
            }
            else if (moduleName.Contains(Convert.ToString(ModuleEnum.Workspace)))
            {
                // click that icon
            }
        }

        /// <summary>
        /// Scroll to an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offset_y"></param>
        /// <param name="scroll_horizontal"></param>
        /// <param name="offset_x"></param>
        public void ScrollToElement(IWebElement element, int offset_y = -200, bool scroll_horizontal = false, int offset_x = -500)
        {
            Wait(_webDriver).Until(d => element.Enabled);

            if (scroll_horizontal)
                ((IJavaScriptExecutor)_webDriver).ExecuteScript("var rect = arguments[0].getBoundingClientRect(); window.scrollBy(rect.left + arguments[1], rect.top + arguments[2]);", element, offset_x, offset_y);
            else
                ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.scrollBy(0, arguments[0].getBoundingClientRect().top + arguments[1]);", element, offset_y);
        }

        //public static IWebElement ScrollIntoView(IWebDriver driver, By locator, bool top = true)
        //{
        //    IWebElement output = ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollIntoView({top.ToString().ToLower()}); return arguments[0];", Wait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator))) as IWebElement;
        //    //Thread.Sleep(100);
        //    return output;
        //}

        /// <summary>
        /// Generic Wait method
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static WebDriverWait Wait(IWebDriver driver, double seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(InvalidOperationException), typeof(NoSuchElementException), typeof(NullReferenceException));
            return wait;
        }

        /// <summary>
        /// Expand the bars based on module name and bar element id
        /// </summary>
        /// <param name="barLocator"></param>
        public void ExpandBar(By barLocator = null)
        {
            IWebElement bar = ScrollIntoView_Center(barLocator);
            try
            {
                if (bar.FindElements(expandBarArrow).Count != 0)
                {
                    IWebElement arrow = bar.FindElement(expandBarArrow);
                    WaitsHelper.WaitUntilClickable(_webDriver, arrow, TimeSpan.FromSeconds(5));
                    arrow.Click();
                }
                else if (bar.FindElements(collapseBarArrow).Count != 0)
                {
                    // dont do anything
                }
                else
                {
                    // Error
                    LogHelper.Error("Error");
                }

                //ScrollToElement(_webDriver, arrow);
                //Actions().MoveToElement(arrow).Click().Perform();
                //Wait(_webDriver).Until(ExpectedConditions.ElementToBeClickable(bar.FindElement(collapseBarArrow)));
            }
            catch
            {
                LogHelper.Error("");
                //Wait(_webDriver, 3).Until(ExpectedConditions.ElementToBeClickable(bar.FindElement(collapseBarArrow)));
            }
        }

        /// <summary>
        /// Scroll to a paticular element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement ScrollIntoView_Center(By element)//, bool top = true)
        {
            IWebElement output = ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center', inline: 'center'}); return arguments[0];", Wait(_webDriver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element))) as IWebElement; //attempt for middle
            return output;
        }

        /// <summary>
        /// Method to mouseover dropdown menu items in panes
        /// </summary>
        /// <param name="elementLocator"></param>
        /// <param name="optionText"></param>
        public void HoverMenuAndSelectOption(By elementLocator, string optionText)
        {
            Actions actions = new Actions(_webDriver);
            IWebElement menuItems;
            menuItems = WaitsHelper.WaitUntilExists(_webDriver, elementLocator, TimeSpan.FromSeconds(40));
            ScrollToElement(menuItems);
            Actions().MoveToElement(menuItems).Build().Perform();
            //Wait for MoveToElement (500), then wait for Css Transition (500).
            Thread.Sleep(1000);

            foreach (IWebElement item in menuItems.FindElements(By.ClassName("rmItem")))
            {
                if (string.Compare(optionText, item.Text, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    item.Click();
                    break;
                }
                //string menuItemText = item.Text;
                //int comparisonResult = string.Compare(optionText, item.Text, StringComparison.OrdinalIgnoreCase);
                //if(comparisonResult == 0)
                //{
                //    item.Click();
                //}
            }


            //Find click target element revealed by hover, and click it
            //IWebElement target = null;
            //foreach (IWebElement option in menu.FindElements(By.XPath("./ul/li/div/ul/li")))
            //{
            //    string found = option.Text.Trim();
            //    if (Regex.IsMatch(found, RegexExact(optionText), RegexOptions.IgnoreCase))
            //    {
            //        string optionClass = option.FindElement(By.TagName("a")).GetAttribute("class");
            //        if (Regex.IsMatch(optionClass, "Disabled", RegexOptions.IgnoreCase) || Regex.IsMatch(optionClass, "HideMe", RegexOptions.IgnoreCase))
            //            throw new ArgumentException("The option \"" + optionText + "\" is disabled");
            //        else
            //        {
            //            target = option;
            //            break;
            //        }
            //    }
            //}

            //if (target is null)
            //    throw new NullReferenceException("Option text \"" + optionText + "\" not found in RadMenu");

            //if (target.Location.Y > menu.Location.Y)
            //    Actions().MoveByOffset(0, ((menu.Size.Height / 2) - 1)).MoveToElement(target).Click(target).Perform();
            //else
            //    Actions().MoveByOffset(0, -((menu.Size.Height / 2) - 1)).MoveToElement(target).Click(target).Perform();
        }
    }
}
