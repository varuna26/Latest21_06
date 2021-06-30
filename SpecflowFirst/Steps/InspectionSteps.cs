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
    public sealed class InspectionSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly DriverHelper _driverHelper;
        CommonPage commonPage;
        WorkspacePage workspacePage;
        //InspectionPage inspectionPage;
        PermittingPage permittingPage;

        public InspectionSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            commonPage = new CommonPage(driverHelper.webDriver);
            workspacePage = new WorkspacePage(driverHelper.webDriver);
            permittingPage = new PermittingPage(driverHelper.webDriver);
        }
    }
}
