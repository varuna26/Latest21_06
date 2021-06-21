using NUnit.Framework;
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
        public PermittingSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            commonPage = new CommonPage(_driverHelper.webDriver);
            workspacePage = new WorkspacePage(_driverHelper.webDriver);
        }

        [Given(@"The user is logged into the application")]
        public void GivenTheUserIsLoggedIntoTheApplication()
        {
            LoginPage loginPage = new LoginPage(_driverHelper.webDriver);
            loginPage.NavigatetoUrl();
            // add common login id pwd and user type to config and fetch from there
            workspacePage = commonPage.Login("vv", "trakit1234");
            //Assert.That(commonPage.GetPageTitle(), Does.Contain(Convert.ToString(ModuleEnum.Workspace)));
        }

        [When(@"The user clicks '(.*)' icon on the left Panel")]
        public void WhenTheUserClicksIconOnTheLeftPanel(string moduleName)
        {
            PermittingPage permittingPage = new PermittingPage(_driverHelper.webDriver);
            workspacePage.HoverandClickLeftPane(moduleName);
            Thread.Sleep(10000);
            //decide whether to put it in CustomControls or CommonPage
            Assert.That(commonPage.getPageTitle(moduleName), Does.Contain(moduleName).IgnoreCase);
        }
    }
}
