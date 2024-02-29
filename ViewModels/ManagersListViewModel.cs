using ProjectMateApp.Commands;
using ProjectMateApp.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ManagersListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ManagerViewModel> _managers;

        public IEnumerable<ManagerViewModel> Managers => _managers;

        public ICommand CreateManager { get; }

        public ManagersListViewModel(NavigationStore navigationStore, Func<CreateManagerViewModel> createManagerViewModel)
        {
            _managers = new ObservableCollection<ManagerViewModel>();

            CreateManager = new NavigateCommand(navigationStore, createManagerViewModel);
        }
    }
}
