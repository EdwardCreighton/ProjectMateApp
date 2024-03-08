using ProjectMateApp.Models;

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

        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
