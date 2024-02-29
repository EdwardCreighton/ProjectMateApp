using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ManagersListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ManagerViewModel> _managers;

        public IEnumerable<ManagerViewModel> Managers => _managers;

        public ICommand CreateManager { get; }

        public ManagersListViewModel(NavigationService toCreateManagerNavigationService)
        {
            _managers = new ObservableCollection<ManagerViewModel>();

            CreateManager = new NavigateCommand(toCreateManagerNavigationService);
        }
    }
}
