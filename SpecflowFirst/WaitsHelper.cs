using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFirst
{
    public class WaitsHelper
    {
        public static WebDriverWait WaitFor(IWebDriver webDriver, TimeSpan timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, timeSpan);
            return wait;
        }

        public static IWebElement WaitUntilExists(IWebDriver webDriver, By elementLocator, TimeSpan timeSpan)
        {
            IWebElement webElement;
            webElement = WaitFor(webDriver, timeSpan).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            return webElement;
        }

        public static IWebElement WaitUntilClickable(IWebDriver webDriver, IWebElement element, TimeSpan timeSpan)
        {
            IWebElement webElement;
            webElement = WaitFor(webDriver, timeSpan).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return webElement;
        }

        public static IWebElement WaitUntilVisible(IWebDriver webDriver, By elementLocator, TimeSpan timeSpan)
        {
            IWebElement webElement;
            webElement = WaitFor(webDriver, timeSpan).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            return webElement;
        }
    }

}
