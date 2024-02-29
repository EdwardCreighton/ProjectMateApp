using ProjectMateApp.Stores;

namespace ProjectMateApp.ViewModels
{
    public class ListingViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public ListingViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
