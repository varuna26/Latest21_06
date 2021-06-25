using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecflowFirst.Pages
{
    public class WorkspacePage
    {
        private IWebDriver _webDriver;

        public WorkspacePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        IWebElement widgetItem_LoadingRow => _webDriver.FindElement(By.XPath("//div[@id='mainContent']//img[contains(@src, 'ajax-loader')]"));
        IWebElement widgetItem_LoadingRowMyTasks => _webDriver.FindElement(By.XPath("//*[@id='RadAjaxPanel1Panel']//img[contains(@src, 'ajax-loader')]"));
      
    }
}