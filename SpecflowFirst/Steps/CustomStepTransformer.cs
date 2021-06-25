using OpenQA.Selenium;
using SpecflowFirst.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowFirst.Steps
{
    public class CustomStepTransformer
    {
        private readonly DriverHelper _driverHelper;
        PermittingPage permittingPage;

        public CustomStepTransformer(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            permittingPage = new PermittingPage(driverHelper.webDriver);
        }

        [StepArgumentTransformation()]
        public ActionType GetPaneType(string actionType)
        {
            ActionType action = (ActionType)Enum.Parse(typeof(ActionType), actionType);
            return action;
        }

        //public IWebElement ReturnEnumsMethod(string paneName, string moduleName)
        //{


        //}

        [StepArgumentTransformation()]
        public By GetBarLocator(string paneName, string moduleName)
        {
            By locator = By.Id("");
            // Permitting
            if (moduleName.Contains(Convert.ToString(ModuleEnum.Permitting)))
            {
                if (paneName.Contains(Convert.ToString(PaneTypeEnum.Permitting)))
                {
                    locator = permittingPage.informationBarLocator;
                }
            }
            return locator;
        }

    }
    
}
