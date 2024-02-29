using ProjectMateApp.Stores;

namespace ProjectMateApp.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
