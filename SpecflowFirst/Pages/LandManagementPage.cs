using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFirst.Pages
{
   public class LandManagementPage
    {
        private readonly IWebDriver _webDriver;
        public LandManagementPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement informationPane => _webDriver.FindElement(By.Id("ctl16_T"));
        public IWebElement ReturnHeaderElement()
        {
            return informationPane;
        }
    }
}
