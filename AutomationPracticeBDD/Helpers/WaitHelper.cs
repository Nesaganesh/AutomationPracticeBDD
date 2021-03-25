using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeBDD.Helpers
{
    public class WaitHelper
    {
        private static IWebElement WaitForElement(IWebDriver driver, By webElementBy, TimeSpan seconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, seconds);
                return wait.Until(ExpectedConditions
                    .ElementExists(webElementBy));
            }
            catch (Exception exception)
            {
                throw new NoSuchElementException($"Waiting {seconds.TotalSeconds}s for element {webElementBy} to exists but it was unsucessful ->  {exception.Message}");
            }
        }
        
        public static IWebElement WaitForElementUntilExists(IWebDriver driver, By webElementBy, double seconds = 20)
        {
            return WaitForElement(driver, webElementBy, TimeSpan.FromSeconds(seconds));
        }
        
        public static TResult WaitUntilCondition<TResult>(IWebDriver driver,Func<IWebDriver, TResult> expectedCondition, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(expectedCondition);
        }
    }
}