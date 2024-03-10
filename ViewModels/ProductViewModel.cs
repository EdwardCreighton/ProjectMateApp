using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Stores;
using System.Windows.Input;

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
        public ICommand Edit { get; }

        public ProductViewModel(NavigationStore navigationStore, NavigationService toEditProductNavigationService, Product product)
        {
            _product = product;
            Edit = new EditProductNavigateCommand(navigationStore, toEditProductNavigationService, _product);
        }
    }
}
