using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Stores;
using ProjectMateApp.ViewModels;

namespace ProjectMateApp.Commands
{
    public class EditClientNavigateCommand : NavigateCommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Client _client;

        public EditClientNavigateCommand(NavigationStore navigationStore,
                                         NavigationService toEditClientNavigationService,
                                         Client client) : base(toEditClientNavigationService)
        {
            _navigationStore = navigationStore;
            _client = client;
        }

        public override void Execute(object? parameter)
        {
            base.Execute(parameter);

            ((EditClientViewModel)_navigationStore.CurrentViewModel).Client = _client;
        }
    }
}
