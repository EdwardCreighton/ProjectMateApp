using ProjectMateApp.Commands;
using ProjectMateApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ClientsListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ClientViewModel> _clients;
        public IEnumerable<ClientViewModel> Clients => _clients;

        public ICommand CreateClient { get; }

        public ClientsListViewModel(NavigationService toCreateClientNavigationService, IDataBase dataBase)
        {
            _clients = new ObservableCollection<ClientViewModel>();

            foreach (var client in dataBase.Clients)
            {
                _clients.Add(new ClientViewModel(client));
            }

            CreateClient = new ClientsListNavigateCommand(toCreateClientNavigationService, dataBase.Managers.Count() > 0);
        }
    }
}
