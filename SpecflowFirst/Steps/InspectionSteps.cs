using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Steps
{
    [Binding]
    public sealed class InspectionSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly DriverHelper _driverHelper;
        public InspectionSteps(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
        }

        [When(@"The user clicks the arrow on far right of '(.*)' section")]
        public void WhenTheUserClicksTheArrowOnFarRightOfSection(string p0)
        {
            
        }

        [Then(@"The '(.*)' section expands")]
        public void ThenTheSectionExpands(string p0)
        {
            
        }

    }
}
