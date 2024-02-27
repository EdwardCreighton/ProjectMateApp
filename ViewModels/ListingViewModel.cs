namespace ProjectMateApp.ViewModels
{
    public class ListingViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public ListingViewModel()
        {
            CurrentViewModel = new ManagersListViewModel();
        }
    }
}
