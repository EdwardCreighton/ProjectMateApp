using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class CreateProductViewModel : BaseViewModel
    {
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

		public ICommand Create { get; }
        public ICommand Cancel { get; }

        public CreateProductViewModel(NavigationService toListingNavigationService, IDataBase dataBase)
        {
            _allTypes = new ObservableCollection<string>()
            {
                "Subscription",
                "Permanent License"
            };

            Create = new CreateProductCommand(toListingNavigationService, dataBase, this);
            Cancel = new NavigateCommand(toListingNavigationService);
        }
    }
}
