using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFirst.Pages
{
    public class GridComponentsPage
    {
        private IWebDriver _webDriver;
        public GridComponentsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

    }
}
