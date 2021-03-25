using System;
using System.Linq;
using AutomationPracticeBDD.Helpers;
using AutomationPracticeBDD.Settings.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeBDD.Pages.PlaceOrder
{
    public class PlaceOrderBase : IPlaceOrder
    {
        public ChromeDriver Driver { get; }
        protected string ProductSelector => "#block_top_menu ul li a";
        protected string AddToCartSelector => "#add_to_cart button";
        protected string AddToCartSelectorText => "Add to cart";
        protected string ProceedToCheckoutPopupSelector => "#layer_cart div.button-container a span";
        protected string CheckoutSelector => "p.cart_navigation span";
        protected string ProductListGridViewSlector = "ul.product_list li";
        protected string TermsConditionSelector = "cgv";
        protected string PaymentSelector = "a.cheque";
        protected string ProceedToCheckoutText => "Proceed to checkout";
        protected string ConfirmOrderText => "I confirm my order";
        protected string SuccessOrderMessageSelector = "p.alert-success";
        protected string SuccessOrderMessage = "Your order on My Store is complete.";

        protected string OrderHistoryDeepLink = "?controller=history";
        protected string OrderListSelector = "#order-list tr";
        
        protected PlaceOrderBase(ChromeDriver driver) => Driver = driver;

        public void SelectProduct(ProductInfo productInfo)
        {
            var productlist = Driver.FindElements(By.CssSelector(ProductSelector));
            var productListTexts = productlist.Select(e => e.Text).ToList();

            Console.WriteLine("Account Information " + productListTexts.Contains(productInfo.ProductName));
            Assert.True(productListTexts.Contains(productInfo.ProductName));

            productlist.FirstOrDefault(e => e.Text.Equals(productInfo.ProductName))?.Click();

            
            Driver.FindElement(By.CssSelector(ProductListGridViewSlector)).Click();
        }

        public void AddToCart()
        {
            var addCartText = Driver.FindElement(By.CssSelector(AddToCartSelector)).Text;
            Assert.True(addCartText.ToLower().Equals(AddToCartSelectorText.ToLower()), $"Button doesnt have {addCartText}");
            WaitHelper.WaitUntilCondition(Driver, 
                    ExpectedConditions.ElementExists(By.CssSelector(AddToCartSelector)), 10)
                .Click();
            
            WaitHelper.WaitUntilCondition(Driver, 
                    ExpectedConditions.ElementIsVisible(By.CssSelector(ProceedToCheckoutPopupSelector)), 10)
                .Click();
        }
        
        public void PlaceOrder()
        {
            ProceedOrder(ProceedToCheckoutText);
            
            ProceedOrder(ProceedToCheckoutText);
            
            Driver.FindElement(By.Id(TermsConditionSelector)).Click();
            
            ProceedOrder(ProceedToCheckoutText);
            
            Driver.FindElement(By.CssSelector(PaymentSelector)).Click();
            
            ProceedOrder(ConfirmOrderText);
            
            var successMessageText = Driver.FindElement(By.CssSelector(SuccessOrderMessageSelector)).Text;
            Assert.True(successMessageText.ToLower().Equals(SuccessOrderMessage.ToLower()), $"Button doesnt have {successMessageText}");
            
        }

        public void VerifyOrder()
        {
            string deepLink = ClientTestConfiguration.TestConfiguration.Environment + OrderHistoryDeepLink;
            Driver.Navigate().GoToUrl(deepLink);

            Assert.True(Driver.FindElements(By.CssSelector(OrderListSelector)).Count > 1, "Placed order information not displayed");

        }

        private void ProceedOrder(string fieldName)
        {
            var checkoutSelectortextElement = WaitHelper.WaitUntilCondition(Driver,
                ExpectedConditions.ElementIsVisible(By.CssSelector(CheckoutSelector)), 10);
            string checkoutSelectortext = checkoutSelectortextElement.Text;
            Assert.True(checkoutSelectortext.ToLower().Equals(fieldName.ToLower()), $"ProceedToCheckoutSelector doesnt have {checkoutSelectortextElement}");
            checkoutSelectortextElement.Click();
        }
        
    }
}