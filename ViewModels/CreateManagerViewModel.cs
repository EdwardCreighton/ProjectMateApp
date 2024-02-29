using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class CreateManagerViewModel : BaseViewModel
    {
        public ICommand Cancel { get; }

        public CreateManagerViewModel(NavigationService toListingNavigationService)
        {
            Cancel = new NavigateCommand(toListingNavigationService);
        }
    }
}
