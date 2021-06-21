using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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
        IWebElement permittingPane => _webDriver.FindElement(By.Id("divIconPermit"));

        IWebElement landManagementPane => _webDriver.FindElement(By.Id("divIconGeo"));

        public void HoverandClickLeftPane(string moduleName)
        {
            // write cases here based on dynamic input in Feature File
            if(moduleName.Contains(Convert.ToString(ModuleEnum.Permit)))
            {
                permittingPane.Click();
            }
            else if(moduleName.Replace(" ", "").Contains(Convert.ToString(ModuleEnum.LandManagement)))
            {
                landManagementPane.Click();
            }
            else if(moduleName.Contains(Convert.ToString(ModuleEnum.Contacts)))
            {
                // click that icon
            }   
        }
    }
}