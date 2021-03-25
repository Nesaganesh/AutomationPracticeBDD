using System;
using System.Security.Policy;
using AutomationPracticeBDD.Common.Constants;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Hooks
{
    [Binding]
    public class WebDriver
    {
        private readonly ScenarioContext _scenarioContext;
        private ChromeDriver Driver;

        public WebDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = (int)HookRunOrder.SpecFlowHooks)]
        public void BeforeTest()
        {

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            _scenarioContext.ScenarioContainer.RegisterInstanceAs(Driver);
            
        }

        [AfterScenario(Order = (int)HookRunOrder.SpecFlowHooks)]
        public void AfterScenario()
        {
            Driver  = _scenarioContext.ScenarioContainer.Resolve<ChromeDriver>();
            if (Driver != null)
            {
                Driver.Dispose();
                Driver = null;
            }
        }
        

    }
}
