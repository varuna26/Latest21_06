using log4net;
using log4net.Config;
using OpenQA.Selenium.Chrome;
using SpecflowFramework.Utilities;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Drivers
{
    
    [Binding]
    public sealed class Hooks
    {
        private DriverHelper _driverHelper;
        private ScenarioContext _scenarioContext;
        public Hooks(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetupBeforeScenario()
        {
            _driverHelper.webDriver = new ChromeDriver();

            LogHelper.Information(_scenarioContext.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void TearDownAfterScenario()
        {
            LogHelper.Information(_scenarioContext.ScenarioExecutionStatus.ToString());
            _driverHelper.webDriver.Quit();
            //LogHelper.Information(_scenarioContext.ScenarioExecutionStatus.ToString());
        }

        //[BeforeFeature]
        //public void SetupBeforeFeature(FeatureContext featureContext)
        //{

        //}

        //[AfterFeature]
        //public void SetupAfterFeature(FeatureContext featureContext)
        //{

        //}

        [BeforeStep]
        public void SetupStep()
        {
            LogHelper.Information(Convert.ToString(_scenarioContext.StepContext.StepInfo.Text));
        }

        [AfterStep]
        public void TearDownStep()
        {
            LogHelper.Information(_scenarioContext.StepContext.Status.ToString());
        }










    }
}
