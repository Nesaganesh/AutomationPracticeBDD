using AutomationPracticeBDD.Pages.Account;
using AutomationPracticeBDD.Pages.PlaceOrder;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Steps.com.Order
{
    [Binding]
    public class OrderSteps
    {
        private readonly ChromeDriver _driver;
        private readonly IPlaceOrder _placeOrder;

        public OrderSteps(IPlaceOrder placeOrder, ChromeDriver driver)
        {
            _driver = driver;
            _placeOrder = placeOrder;
        }


        [When(@"I select product '(.*)'")]
        public void WhenISelectProduct(string product)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.ProductName = product;
            _placeOrder.SelectProduct(productInfo);

        }

        [Then(@"Select the available product")]
        public void ThenSelectTheAvailableProduct()
        {
            _placeOrder.AddToCart();
        }

        [Then(@"Continue and Place Order")]
        public void ThenContinueAndPlaceOrder()
        {
            _placeOrder.PlaceOrder();
        }

        [Then(@"Verify the placed order in the accounts order history")]
        public void ThenVerifyThePlacedOrderInTheAccountsOrderHistory()
        {
            _placeOrder.VerifyOrder();
        }
    }
}
