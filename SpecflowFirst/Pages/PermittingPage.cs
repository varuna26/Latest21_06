using OpenQA.Selenium;
using System;
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

        public IWebElement txtDescription => _webDriver.FindElement(By.Id("ctl09_C_ctl00_txtDescription"));
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

        /// <summary>
        /// Return header on the Permitting screen, needed for assertion
        /// </summary>
        /// <returns></returns>
        public IWebElement ReturnHeaderElement()
        {
            return informationPane;
        }

        /// <summary>
        /// Method to hover the downward arrow and open permitting record in edit mode on the main pane
        /// </summary>
        /// <param name="actionText"></param>
        public void EditPermitting(string actionText)
        {
            HoverMenuAndSelectOption(mainMenuLocator, actionText);
            EditPermitting();
        }

        /// <summary>
        /// Method to edit/update required fields on Permitting
        /// </summary>
        public void EditPermitting()
        {
            // change a text box value and a ddl selection
            EnterText(txtDescription, "Test Description");
        }

        /// <summary>
        /// Method to open Notes Window and Switch to the window
        /// </summary>
        public void AddNotesOnPermitting()
        {
            ClickElement(btnAddNotes);

            //WaitsHelper.WaitUntilFrameAvailableAndSwitch(_webDriver, newWindowFrame, TimeSpan.FromSeconds(15));

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            SwitchToFrame(newWindowFrame);
        }

        /// <summary>
        /// Method to Add arbitrary text to Notes, Save and Close the Window
        /// </summary>
        public void SaveNotesOnPermitting()
        {
            notesPage.SaveNotes(FrameNameEnum.FRMPERMIT);
        }

        /// <summary>
        /// Hover over the Notes button to see the text saved
        /// </summary>
        public void HoverNotesOnPermitting()
        {
            By btnLocator = By.Id("ctl09_C_ctl00_btnAddNotes");
            HoverElement(btnLocator, btnAddNotes);
            //loginPage.LogOut();
        }

        /// <summary>
        /// Method to Save a permitting record after Add/Update
        /// </summary>
        public void SavePermitting()
        {
            ClickElement(btnSavePermitting);
            //loginPage.LogOut();
        }

        /// <summary>
        /// Method to open the permitting screen by clicking the Permitting icon on Workspace
        /// </summary>
        public void ClickPermittingIcon()
        {
            By iconLocator = By.Id("divIconPermit");
            By labelLocator = By.Id("spanIconPermit");
            WaitsHelper.WaitUntilClickable(_webDriver, iconPermitting, TimeSpan.FromSeconds(20));

            HoverElement(iconLocator, iconPermitting);
            HoverElement(labelLocator, lblIconPermitting);

            lblIconPermitting.Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            SwitchToFrame(Convert.ToString(FrameNameEnum.FRMPERMIT));
        }
    }
}
