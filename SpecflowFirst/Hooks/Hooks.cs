using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Drivers
{
    //  Logging goes here

    [Binding]
    public sealed class Hooks
    {
        DriverHelper _driverHelper;

        public Hooks(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void SetupBeforeScenario()
        {
            _driverHelper.webDriver = new ChromeDriver();
        }

        [AfterScenario]
        public void SetupAfterScenario()
        {
            _driverHelper.webDriver.Quit();
        }

        //[BeforeFeature]
        //public void SetupBeforeFeature(FeatureContext featureContext)
        //{

        //}

        //[AfterFeature]
        //public void SetupAfterFeature(FeatureContext featureContext)
        //{

        //}

        //[BeforeStep]
        //public void SetupStep()
        //{

        //}

        //[AfterStep]
        //public void TearDownStep()
        //{ }










    }
}
