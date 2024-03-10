using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Stores;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly IDataBase _dataBase;

        public App()
        {
            _navigationStore = new NavigationStore();
            _dataBase = new DataBaseModel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = ListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        public ListingViewModel ListingViewModel()
        {
            return new ListingViewModel(this, _navigationStore, _dataBase);
        }

        public CreateManagerViewModel CreateManagerViewModel()
        {
            return new CreateManagerViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        public CreateProductViewModel CreateProductViewModel()
        {
            return new CreateProductViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        public CreateClientViewModel CreateClientViewModel()
        {
            return new CreateClientViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        public EditManagerViewModel EditManagerViewModel()
        {
            return new EditManagerViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        public EditClientViewModel EditClientViewModel()
        {
            return new EditClientViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        public EditProductViewModel EditProductViewModel()
        {
            return new EditProductViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }
    }
}
