using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ProductsListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;

        public ICommand CreateProduct { get; }

        public ProductsListViewModel(NavigationService toCreateProductNavigationService, IDataBase dataBase)
        {
            _products = new ObservableCollection<ProductViewModel>();

            foreach (var product in dataBase.Products)
            {
                _products.Add(new ProductViewModel(product));
            }

            CreateProduct = new NavigateCommand(toCreateProductNavigationService);
        }
    }
}
