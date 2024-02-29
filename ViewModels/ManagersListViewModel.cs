using ProjectMateApp.Commands;
using ProjectMateApp.Models;
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

        public ManagersListViewModel(NavigationService toCreateManagerNavigationService, IDataBase dataBase)
        {
            _managers = new ObservableCollection<ManagerViewModel>();

            IEnumerable<Manager> dataBaseManagers = dataBase.GetManagers();

            foreach (Manager manager in dataBaseManagers)
            {
                _managers.Add(new ManagerViewModel(manager));
            }

            CreateManager = new NavigateCommand(toCreateManagerNavigationService);
        }
    }
}
