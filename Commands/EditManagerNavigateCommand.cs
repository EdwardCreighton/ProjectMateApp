using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Stores;
using ProjectMateApp.ViewModels;

namespace ProjectMateApp.Commands
{
    public class EditManagerNavigateCommand : NavigateCommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Manager _manager;

        public EditManagerNavigateCommand(NavigationStore navigationStore,
                                          NavigationService toEditManagerNavigationService,
                                          Manager manager) : base(toEditManagerNavigationService)
        {
            _navigationStore = navigationStore;
            _manager = manager;
        }

        public override void Execute(object? parameter)
        {
            base.Execute(parameter);

            ((EditManagerViewModel)_navigationStore.CurrentViewModel).Manager = _manager;
        }
    }
}
