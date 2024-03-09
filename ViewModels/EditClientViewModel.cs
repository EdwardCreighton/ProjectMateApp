using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class EditClientViewModel : BaseViewModel
    {
        private Client _client;
        public Client Client
        {
            get => _client;
            set
            {
                _client = value;
                if (_client != null)
                {
                    NameValidator.SeparateName(_client.Name, out _firstName, out _surname, out _lastName);
                    SelectedStatusIndex = (int)_client.Status;
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private int _selectedStatusIndex;
        public int SelectedStatusIndex
        {
            get
            {
                return _selectedStatusIndex;
            }
            set
            {
                _selectedStatusIndex = value;
                OnPropertyChanged(nameof(SelectedStatusIndex));
            }
        }

        private readonly ObservableCollection<string> _allStatuses;
        public IEnumerable<string> AllStatuses => _allStatuses;

        private int _selectedManagerIndex;
        public int SelectedManagerIndex
        {
            get
            {
                return _selectedManagerIndex;
            }
            set
            {
                _selectedManagerIndex = value;
                OnPropertyChanged(nameof(SelectedManagerIndex));
            }
        }

        private readonly ObservableCollection<ManagerViewModel> _allManagers;
        public IEnumerable<ManagerViewModel> AllManagers => _allManagers;

        public ICommand Apply { get; }
        public ICommand Cancel { get; }
        public ICommand Delete { get; }

        public EditClientViewModel(NavigationService toListingNavigationService, IDataBase dataBase)
        {
            _allManagers = new ObservableCollection<ManagerViewModel>();

            foreach (var manager in dataBase.Managers)
            {
                _allManagers.Add(new ManagerViewModel(manager));
            }

            _allStatuses = new ObservableCollection<string>()
            {
                "Default",
                "VIP"
            };

            Apply = new ApplyClientChangesCommand(this, toListingNavigationService, dataBase);
            Cancel = new NavigateCommand(toListingNavigationService);
            Delete = new DeleteClientCommand(this, toListingNavigationService, dataBase);
        }
    }
}
