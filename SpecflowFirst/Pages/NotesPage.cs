using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecflowFirst.Pages
{
    public class NotesPage
    {
        private IWebDriver _webDriver;
        CommonPage common;
        public NotesPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            common = new CommonPage(webDriver);
        }
       public IWebElement txtAreaNotes => _webDriver.FindElement(By.Id("ctl08_txtNoteSave"));

       public IWebElement btnSaveNotes => _webDriver.FindElement(By.Id("ctl08_btnSave"));


       public IWebElement notesButtonToolTip => _webDriver.FindElement(By.XPath("//*[@id='RadToolTipWrapper_ctl09_C_ctl00_rttNotes']/table/tbody/tr[2]/td[2]/div/div"));

        public void SaveNotes()
        {
            common.EnterText(txtAreaNotes, "test text to be entered and verified if it works fine");
            common.ClickElement(btnSaveNotes);
            Thread.Sleep(5000);
        }
    }
}
