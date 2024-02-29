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
        private readonly NavigationStore _mainWindowNavigationStore;
        private readonly NavigationStore _listingNavigationStore;

        public App()
        {
            _mainWindowNavigationStore = new NavigationStore();
            _listingNavigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _mainWindowNavigationStore.CurrentViewModel = new ListingViewModel(_listingNavigationStore);
            _listingNavigationStore.CurrentViewModel = new ManagersListViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_mainWindowNavigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
