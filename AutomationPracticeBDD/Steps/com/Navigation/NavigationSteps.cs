using AutomationPracticeBDD.Pages.Account;
using AutomationPracticeBDD.Settings.Models;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Steps.com.Navigation
{
    [Binding]
    public class NavigationSteps
    {
        private readonly ChromeDriver _driver;

        public NavigationSteps(ChromeDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to AutomationPractice website")]
        public void GivenINavigateToAutomationPracticeWebsite()
        {
            _driver.Navigate().GoToUrl(ClientTestConfiguration.TestConfiguration.Environment);
        }

    }
}