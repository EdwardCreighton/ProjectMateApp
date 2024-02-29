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

        public App()
        {
            _navigationStore = new NavigationStore();
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

        private CreateManagerViewModel CreateManagerViewModel()
        {
            return new CreateManagerViewModel(_navigationStore, ListingViewModel);
        }

        private ListingViewModel ListingViewModel()
        {
            return new ListingViewModel(_navigationStore, CreateManagerViewModel);
        }
    }
}
