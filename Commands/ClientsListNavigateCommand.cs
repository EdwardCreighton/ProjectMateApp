using ProjectMateApp.Services;

namespace ProjectMateApp.Commands
{
    public class ClientsListNavigateCommand : NavigateCommand
    {
        private readonly bool _canExecute;

        public ClientsListNavigateCommand(NavigationService navigationService, bool canExecute) : base(navigationService)
        {
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute
                && base.CanExecute(parameter);
        }
    }
}
