namespace AutomationPracticeBDD.Pages.PlaceOrder
{
    public interface IPlaceOrder
    {
        void SelectProduct(ProductInfo product);
        void AddToCart();
        void PlaceOrder();
        void VerifyOrder();
    }
}