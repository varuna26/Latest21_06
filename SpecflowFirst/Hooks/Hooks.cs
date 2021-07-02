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
        private FeatureContext _featureContext;
        public Hooks(DriverHelper driverHelper, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        [BeforeScenario]
        public void SetupBeforeScenario()
        {
            _driverHelper.webDriver = new ChromeDriver();
        }

        [BeforeScenarioBlock]
        public void SetupGiven()
        {
            if (_scenarioContext.CurrentScenarioBlock == ScenarioBlock.Given)
            {
                LogHelper.Information("Scenario Started");
                LogHelper.Information(_scenarioContext.ScenarioInfo.Title);
            }
        }

        [AfterScenario]
        public void TearDownAfterScenario()
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                LogHelper.Information("Success");
            }
            else if ((_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError) || (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.BindingError))
            {
                LogHelper.Information("Failure");
            }

            LogHelper.Information("Scenario Ended");

            _driverHelper.webDriver.Quit();
            //LogHelper.Information(_scenarioContext.ScenarioExecutionStatus.ToString());
        }

        //[BeforeFeature]
        //public void SetupBeforeFeature(FeatureContext featureContext)
        //{
        //    LogHelper.Information("Feature Started");
        //    LogHelper.Information(_featureContext.FeatureInfo.Title);
        //}

        //[AfterFeature]
        //public void SetupAfterFeature(FeatureContext featureContext)
        //{
        //    LogHelper.Information("Feature Ended");
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
