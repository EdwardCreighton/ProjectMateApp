using ProjectMateApp.ViewModels;

namespace ProjectMateApp.Stores
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
            }
        }
    }
}
