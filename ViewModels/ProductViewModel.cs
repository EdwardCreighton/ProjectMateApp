using ProjectMateApp.Models;

namespace ProjectMateApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly Product _product;

        public string Name => _product.Name;
        public string Price => _product.Price.ToString();
        public string Type
        {
            get
            {
                return _product.Type switch
                {
                    ProductType.Subscription => "Subscription",
                    ProductType.PermanentLicense => "Permanent License"
                };
            }
        }
        public string SubscriptionExpirationDate => _product.Type == ProductType.Subscription ? _product.SubscriptionExpirationDate.ToString("d") : string.Empty;

        public ProductViewModel(Product product)
        {
            _product = product;
        }
    }
}
