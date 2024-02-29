using ProjectMateApp.Commands;
using ProjectMateApp.Stores;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class CreateManagerViewModel : BaseViewModel
    {
        public ICommand Cancel { get; }

        public CreateManagerViewModel(NavigationStore navigationStore, Func<BaseViewModel> createListingViewModel)
        {
            Cancel = new NavigateCommand(navigationStore, createListingViewModel);
        }
    }
}
