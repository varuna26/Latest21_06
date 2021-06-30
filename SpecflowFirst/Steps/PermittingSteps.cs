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
        //WorkspacePage workspacePage;
        PermittingPage permittingPage;
        //NotesPage notesPage;
        LoginPage loginPage;
        public PermittingSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            commonPage = new CommonPage(_driverHelper.webDriver);
            //workspacePage = new WorkspacePage(_driverHelper.webDriver);
            permittingPage = new PermittingPage(_driverHelper.webDriver);
            //notesPage = new NotesPage(_driverHelper.webDriver);
            loginPage = new LoginPage(driverHelper.webDriver);
        }
        
        [Given(@"The user is logged into the application")]
        public void GivenTheUserIsLoggedIntoTheApplication()
        {
            loginPage.AppLogin("vv", "trakit1234");
        }

        [Given(@"The user is on '(.*)' screen")]
        public void GivenTheUserIsOnScreen(string moduleName)
        {
            permittingPage.ClickLeftPanelIcons(moduleName);
            //Thread.Sleep(1000);
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
            {
                permittingPage.AddNotesOnPermitting();
            }
        }

        [When(@"The user Saves Notes on the window")]
        public void WhenTheUserSavesNotesOnTheWindow()
        {
            permittingPage.SaveNotesOnPermitting();
        }

        [Then(@"The text entered should be visible when the user hovers over the Notes button")]
        public void ThenTheTextEnteredShouldBeVisibleWhenTheUserHoversOverTheNotesButton()
        {
            permittingPage.HoverNotesOnPermitting();
        }

        [When(@"The user '(.*)' Permitting")]
        public void WhenTheUserPermitting(ActionType action)
        {
            string actionText = Convert.ToString(action);
            if (action == ActionType.Edit)
            {
                permittingPage.EditPermitting(actionText);
            }
        }

        [Then(@"The user should be able to Save Permitting")]
        public void ThenTheUserShouldBeAbleToSavePermitting()
        {
            permittingPage.SavePermitting();
        }
    }
}
