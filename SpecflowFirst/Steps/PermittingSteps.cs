using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowFirst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Steps
{
    [Binding]
    public sealed class PermittingSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly DriverHelper _driverHelper;
        CommonPage commonPage;
        WorkspacePage workspacePage;
        PermittingPage permittingPage;
        NotesPage notesPage;
        public PermittingSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            commonPage = new CommonPage(_driverHelper.webDriver);
            workspacePage = new WorkspacePage(_driverHelper.webDriver);
            permittingPage = new PermittingPage(_driverHelper.webDriver);
            notesPage = new NotesPage(_driverHelper.webDriver);
        }
        
        [Given(@"The user is logged into the application")]
        public void GivenTheUserIsLoggedIntoTheApplication()
        {
            commonPage.NavigatetoUrl();
            // add common login id pwd and user type to config and fetch from there
            commonPage.Login("vv", "trakit1234");
            //Assert.That(commonPage.GetPageTitle(), Does.Contain(Convert.ToString(ModuleEnum.Workspace)));
        }

        [Given(@"The user is on '(.*)' screen")]
        public void GivenTheUserIsOnScreen(string moduleName)
        {
            PermittingPage permittingPage = new PermittingPage(_driverHelper.webDriver);
            commonPage.ClickLeftPanelIcons(moduleName);
            Thread.Sleep(1000);
            Assert.That(commonPage.getPageTitle(moduleName), Does.Contain(moduleName).IgnoreCase);
        }

        [Given(@"'(.*)' on '(.*)' is expanded")]
        public void GivenOnIsExpanded(string paneName, string moduleName)
        {
            By barLocator = By.Id("");
            if(paneName.Contains(Convert.ToString(PaneTypeEnum.Permitting)))
            {
                barLocator = By.Id("ctl09_T");
            }
            else if(paneName.Contains(Convert.ToString(PaneTypeEnum.Inspections)))
            {
                barLocator = By.Id("ctl14_T");
            }
            commonPage.ExpandBar(barLocator);
        }

        //[Given(@"'(.*)' on '(.*)' is expanded")]
        //public void GivenOnIsExpanded(By locator)
        //{
        //    commonPage.ExpandBar(locator);
        //}

        [Given(@"The user '(.*)' Notes")]
        public void GivenTheUserNotes(ActionType action)
        {
            if (action == ActionType.Add)
                commonPage.ClickElement(permittingPage.btnAddNotes);
            commonPage.SwitchToFrame(commonPage.newWindowFrame);
        }

        [When(@"The user Saves Notes on the window")]
        public void WhenTheUserSavesNotesOnTheWindow()
        {
            notesPage.SaveNotes();
            commonPage.SwitchToFrame(Convert.ToString(FrameNameEnum.FRMPERMIT));
        }

        [Then(@"The text entered should be visible when the user hovers over the Notes button")]
        public void ThenTheTextEnteredShouldBeVisibleWhenTheUserHoversOverTheNotesButton()
        {
            commonPage.HoverElement(permittingPage.btnAddNotes);
        }

        [When(@"The user '(.*)' Inspection")]
        public void WhenTheUserInspection(ActionType action)
        {
            if (action == ActionType.Add)
            {
                commonPage.ClickElement(permittingPage.btnAddInspection);
            }
                commonPage.SwitchToFrame(commonPage.newWindowFrame);
        }

        [When(@"The user '(.*)' Permitting")]
        public void WhenTheUserPermitting(ActionType action)
        {
            string actionText = Convert.ToString(action);
            if (action == ActionType.Edit)
            {
                commonPage.HoverMenuAndSelectOption(permittingPage.mainMenuLocator, actionText);
            }
        }

        [Then(@"The user should be able to update Permitting")]
        public void ThenTheUserShouldBeAbleToUpdatePermitting()
        {
          
        }

    }
}
