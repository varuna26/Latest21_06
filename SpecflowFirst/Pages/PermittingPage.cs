using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace SpecflowFirst.Pages
{
    public class PermittingPage : CommonPage
    {
        private IWebDriver _webDriver;
        //CommonPage common;
        NotesPage notesPage;
        LoginPage loginPage;
        public PermittingPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
            notesPage = new NotesPage(webDriver);
            loginPage = new LoginPage(webDriver);
        }

        //use string[1] for options that cannot change
        //use string[n] for options that can change to multiple values (n values)
        public static List<string[]> menuOptions = new List<string[]> {
            new string[1] { "Edit" },
            new string[1] { "Add Record" },
            new string[1] { "Duplicate" },
            new string[1] { "Link to..." },
            new string[1] { "Edit Type/Subtype" },
            new string[1] { "Add Additional Sites" },
            new string[1] { "View Timeline" },
            new string[2] { "Follow Permit", "Un-Follow Permit" },
            new string[1] { "Break Link" },
            new string[1] { "Send Email" }
        };

        public const int typeCode = 2;
        public IWebElement btnAddNotes => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnAddNotes"));
        public IWebElement informationPane => _webDriver.FindElement(By.Id("ctl09"));
        public IWebElement informationBar => _webDriver.FindElement(By.Id("ctl09_T"));
        public IWebElement btnAddInspection => _webDriver.FindElement(By.Id("ctl14_C_ctl00_btnAddInspection"));
        IWebElement inspectionPane => _webDriver.FindElement(By.Id("ctl14"));
        public IWebElement inspectionBar => _webDriver.FindElement(By.Id("ctl14_T"));
        public IWebElement mainMenu => _webDriver.FindElement(By.Id("ctl09_C_ctl00_radActionsMenu"));
        public IWebElement btnSavePermitting => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnSave"));
        public By informationBarLocator => By.Id("ctl09_T");
        public By mainMenuLocator => By.Id("ctl09_C_ctl00_radActionsMenu");
        IWebElement ddlPermittingStatus => _webDriver.FindElement(By.Id("ctl09_C_ctl00_ddStatus_Input"));
        public IWebElement ReturnHeaderElement()
        {
            return informationPane;
        }

        public void EditPermitting(string actionText)
        {
            HoverMenuAndSelectOption(mainMenuLocator, actionText);
            EditPermitting();
        }

        public void EditPermitting()
        {
            // change a text box value and a ddl selection
        }

        public void AddNotesOnPermitting()
        {
            ClickElement(btnAddNotes);
            Thread.Sleep(1000);
            SwitchToFrame(newWindowFrame);
        }

        public void SaveNotesOnPermitting()
        {
            notesPage.SaveNotes(FrameNameEnum.FRMPERMIT);
        }

        public void HoverNotesOnPermitting()
        {
            HoverElement(btnAddNotes);
            loginPage.LogOut();
        }

        public void SavePermitting()
        {
            ClickElement(btnSavePermitting);
            //loginPage.LogOut();
        }
    }
}
