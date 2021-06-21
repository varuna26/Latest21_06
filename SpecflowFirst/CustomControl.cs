using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecflowFirst.PageObjects
{
    public static class CustomControl
    {
        public static void EnterText(this IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
        }

        public static void ButtonClick(this IWebElement webElement)
        {
            webElement.Click();
        }

        public static void SelectDropdownByValue(this IWebElement webElement, string value)
        {
            new SelectElement(webElement).SelectByValue(value);
        }

        public static void SelectDropdownByText(this IWebElement webElement, string text)
        {
            new SelectElement(webElement).SelectByValue(text);
        }

        public static void PageForward(this IWebDriver webDriver)
        {
            webDriver.Navigate().Forward();
        }

        public static void PageBackward(this IWebDriver webDriver)
        {
            webDriver.Navigate().Back();
        }

        public static void PageRefresh(this IWebDriver webDriver)
        {
            webDriver.Navigate().Refresh();
        }

        public static void HoverandClickElement(this IWebElement webElement)
        {

        }
    }
}
