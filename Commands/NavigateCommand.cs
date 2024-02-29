using ProjectMateApp.Stores;
using ProjectMateApp.ViewModels;

namespace ProjectMateApp.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel.Invoke();
        }
    }
}
