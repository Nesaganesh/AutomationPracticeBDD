using AutomationPracticeBDD.Pages.Account;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Steps.com.Accounts
{
    [Binding]
    public class AccountSteps
    {
        private readonly ChromeDriver _driver;
        private readonly IAccount _account;

        public AccountSteps(IAccount account, ChromeDriver driver)
        {
            _driver = driver;
            _account = account;
        }

        [When(@"I sign in with username '(.*)' and password '(.*)'")]
        public void WhenISignInWithUsernameAndPassword(string userName, string password)
        {
            _account.Login(userName, password);
        }

        [Then(@"I see account home page")]
        public void ThenISeeAccountHomePage()
        {
            Assert.IsTrue(_account.VerifyHomePage(), "My account page not displayed");
        }

        [When(@"I deeplink to my personal information page")]
        public void WhenIDeeplinkToMyPersonalInformationPage()
        {
            _account.DeepLinkToAccountInfo();
        }

        [Then(@"Update FirstName '(.*)' Password '(.*)'")]
        public void ThenUpdateFirstNameAlexRajPasswordAlex246(string firstName, string password)
        {
            _account.UpdateAccountInfo(firstName, password);
        }

        [Then(@"Save the information")]
        public void ThenSaveTheInformation()
        {
            _account.SaveAccountInfo();
        }

        [Then(@"Veriy the FirstName as '(.*)'")]
        public void ThenVeriyTheFirstNameAsAlexRaj(string firstName)
        {
            _account.VerifyAccountInfo(firstName);
        }
    }
}
