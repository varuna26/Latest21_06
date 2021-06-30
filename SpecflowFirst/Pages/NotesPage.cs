using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecflowFirst.Pages
{
    public class NotesPage : CommonPage
    {
        private IWebDriver _webDriver;
        CommonPage common;
        public NotesPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
            common = new CommonPage(webDriver);
        }
       public IWebElement txtAreaNotes => _webDriver.FindElement(By.Id("ctl08_txtNoteSave"));

       public IWebElement btnSaveNotes => _webDriver.FindElement(By.Id("ctl08_btnSave"));


       public IWebElement notesButtonToolTip => _webDriver.FindElement(By.XPath("//*[@id='RadToolTipWrapper_ctl09_C_ctl00_rttNotes']/table/tbody/tr[2]/td[2]/div/div"));

        public void SaveNotes(FrameNameEnum frameNameEnum)
        {
            // wait until window elements are loaded
            
            common.EnterText(txtAreaNotes, "Test Data");
            common.ClickElement(btnSaveNotes);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Thread.Sleep(5000);
            SwitchToFrame(Convert.ToString(frameNameEnum));
        }
    }
}
