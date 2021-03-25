using System;
using AutomationPracticeBDD.Settings.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeBDD.Pages.Account
{
    public class AccountBase : IAccount
    {
        public ChromeDriver Driver { get; }
        protected virtual string SignInSelector => "div.header_user_info a";
        protected virtual string UserNameInSelector => "#email";
        protected virtual string PasswordSelector => "#passwd";
        protected virtual string SubmitLoginSelector => "#SubmitLogin";

        protected virtual string AccountInfoSelector => "div.center_column h1";

        protected string DeepLinkPersonalInfo = "?controller=identity";
        protected string VerifyAccountPageSelector => "div.center_column h1";
        protected string VerifyAccountPageText => "Your personal information";
        
        
        protected string FirstNameSelector => "#firstname";
        protected string OldPasswordSelector => "#old_passwd";
        protected string NewPasswordSelector => "#passwd";
        protected string ConfirmPasswordSelector => "#confirmation";

        protected string SaveButtonSelector => "div.form-group button";

        protected AccountBase(ChromeDriver driver) => Driver = driver;

        public virtual void Login(string userName, string password)
        {
            Driver.FindElement(By.CssSelector(SignInSelector)).Click();

            Driver.FindElement(By.CssSelector(UserNameInSelector)).SendKeys(userName);
            Driver.FindElement(By.CssSelector(PasswordSelector)).SendKeys(password);

            Driver.FindElement(By.CssSelector(SubmitLoginSelector)).Click();

        }

        public virtual bool VerifyHomePage()
        {
            string accountInfo = Driver.FindElement(By.CssSelector(AccountInfoSelector)).Text;
            Console.WriteLine("Account Information " + accountInfo);
            return accountInfo.Equals("MY ACCOUNT");
        }

        public void DeepLinkToAccountInfo()
        {
            string deepLink = ClientTestConfiguration.TestConfiguration.Environment + DeepLinkPersonalInfo;
            Driver.Navigate().GoToUrl(deepLink);

            var infoText = Driver.FindElement(By.CssSelector(VerifyAccountPageSelector)).Text; 
            Assert.True(infoText.ToLower().Trim().Equals(VerifyAccountPageText.ToLower().Trim()), "Not in  Personal info page");
        }

        public void UpdateAccountInfo(string firstName, string password)
        {
            Driver.FindElement(By.CssSelector(FirstNameSelector)).Clear();
            Driver.FindElement(By.CssSelector(FirstNameSelector)).SendKeys(firstName);
            
            Driver.FindElement(By.CssSelector(OldPasswordSelector)).SendKeys(password);
            Driver.FindElement(By.CssSelector(NewPasswordSelector)).SendKeys(password);
            Driver.FindElement(By.CssSelector(ConfirmPasswordSelector)).SendKeys(password);
        }

        public void SaveAccountInfo()
        {
            Driver.FindElement(By.CssSelector(SaveButtonSelector)).Click();
        }

        public void VerifyAccountInfo(string firstName)
        {
            DeepLinkToAccountInfo();

            var firstNameFromPage = Driver.FindElement(By.CssSelector(FirstNameSelector)).GetAttribute("value");
            Assert.True(firstName.Equals(firstNameFromPage), "first Name in the accounts page is updated ");

        }
    }
}
