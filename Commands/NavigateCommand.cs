using ProjectMateApp.Services;

namespace ProjectMateApp.Commands
{
    public class NavigateCommand : BaseCommand
    {
        protected readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
