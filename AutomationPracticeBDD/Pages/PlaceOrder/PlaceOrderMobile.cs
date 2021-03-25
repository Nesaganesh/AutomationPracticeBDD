using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeBDD.Pages.PlaceOrder
{
    public class PlaceOrderMobile : PlaceOrderBase
    {
        protected virtual string UserNameCss => "[class*='usernameInput'] input";

        public PlaceOrderMobile(ChromeDriver driver) : base(driver)
        {
        }
       
    }
}