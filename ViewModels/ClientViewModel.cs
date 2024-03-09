using ProjectMateApp.Commands;
using ProjectMateApp.Models;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private readonly Client _client;

        public string Name => _client.Name;
        public string Status
        {
            get
            {
                return _client.Status switch
                {
                    ClientStatus.DefaultClient => "Default",
                    ClientStatus.ImportantClient => "VIP"
                };
            }
        }
        public string ManagerName => _client.Manager.Name;

        public ICommand Edit { get; }

        public ClientViewModel(Client client)
        {
            _client = client;
        }

        public ClientViewModel(Client client, BaseCommand editCommand)
        {
            _client = client;
            Edit = editCommand;
        }
    }
}
