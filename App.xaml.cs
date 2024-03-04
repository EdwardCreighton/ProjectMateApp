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

        private ListingViewModel ListingViewModel()
        {
            return new ListingViewModel(new NavigationService(_navigationStore, CreateManagerViewModel),
                                        new NavigationService(_navigationStore, CreateClientViewModel),
                                        new NavigationService(_navigationStore, CreateProductViewModel),
                                        _dataBase);
        }

        private CreateManagerViewModel CreateManagerViewModel()
        {
            return new CreateManagerViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        private CreateProductViewModel CreateProductViewModel()
        {
            return new CreateProductViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }

        private CreateClientViewModel CreateClientViewModel()
        {
            return new CreateClientViewModel(new NavigationService(_navigationStore, ListingViewModel), _dataBase);
        }
    }
}
