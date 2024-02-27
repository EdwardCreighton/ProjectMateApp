namespace ProjectMateApp.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new ListingViewModel();
        }
    }
}
