using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class EditProductViewModel : BaseViewModel
    {
        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                if (_product != null)
                {
                    _name = _product.Name;
                    _price = _product.Price.ToString();
                    _selectedType = (int)_product.Type;
                    _subsciptionExpirationDate = _product.SubscriptionExpirationDate;
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _selectedType;
        public int SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private DateTime _subsciptionExpirationDate = DateTime.UtcNow;
        public DateTime SubscriptionExpirationDate
        {
            get
            {
                return _subsciptionExpirationDate;
            }
            set
            {
                _subsciptionExpirationDate = value;
                OnPropertyChanged(nameof(SubscriptionExpirationDate));
            }
        }

        private readonly ObservableCollection<string> _allTypes;
        public IEnumerable<string> AllTypes => _allTypes;

        public ICommand Apply { get; }
        public ICommand Cancel { get; }
        public ICommand Delete { get; }

        public EditProductViewModel(NavigationService toListingNavigationService, IDataBase dataBase)
        {
            _allTypes = new ObservableCollection<string>()
            {
                "Subscription",
                "Permanent License"
            };

            Apply = new ApplyProductChangesCommand(this, toListingNavigationService, dataBase);
            Cancel = new NavigateCommand(toListingNavigationService);
            Delete = new DeleteProductCommand(this, toListingNavigationService, dataBase);
        }
    }
}
