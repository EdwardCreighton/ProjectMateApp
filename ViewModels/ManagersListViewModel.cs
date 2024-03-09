using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
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

        public ManagersListViewModel(NavigationStore navigationStore,
                                     NavigationService toCreateManagerNavigationService,
                                     NavigationService toEditManagerNavigationService,
                                     IDataBase dataBase)
        {
            _managers = new ObservableCollection<ManagerViewModel>();

            IEnumerable<Manager> dataBaseManagers = dataBase.Managers;

            foreach (Manager manager in dataBaseManagers)
            {
                _managers.Add(new ManagerViewModel(manager, new EditManagerNavigateCommand(navigationStore, toEditManagerNavigationService, manager)));
            }

            CreateManager = new NavigateCommand(toCreateManagerNavigationService);
        }
    }
}
