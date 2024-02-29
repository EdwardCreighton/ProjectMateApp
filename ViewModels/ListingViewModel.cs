namespace ProjectMateApp.ViewModels
{
    public class ListingViewModel : BaseViewModel
    {
        private readonly ManagersListViewModel _managersListViewModel;
        private readonly ClientsListViewModel _clientsListViewModel;
        private readonly ProductsListViewModel _productsListViewModel;
        private readonly ManagerToClientsListViewModel _managerToClientsListViewModel;
        private readonly ClientToProductsListViewModel _clientToProductsListViewModel;
        private readonly StatusToClientsListViewModel _statusToClientsListViewModel;

        public ManagersListViewModel ManagersListViewModel => _managersListViewModel;
        public ClientsListViewModel ClientsListViewModel => _clientsListViewModel;
        public ProductsListViewModel ProductsListViewModel => _productsListViewModel;
        public ManagerToClientsListViewModel ManagerToClientsListViewModel => _managerToClientsListViewModel;
        public ClientToProductsListViewModel ClientToProductsListViewModel => _clientToProductsListViewModel;
        public StatusToClientsListViewModel StatusToClientsListViewModel => _statusToClientsListViewModel;

        public ListingViewModel(Services.NavigationService toCreateManagerNavigationService)
        {
            _managersListViewModel = new ManagersListViewModel(toCreateManagerNavigationService);
            _clientsListViewModel = new ClientsListViewModel();
            _productsListViewModel = new ProductsListViewModel();
            _managerToClientsListViewModel = new ManagerToClientsListViewModel();
            _clientToProductsListViewModel = new ClientToProductsListViewModel();
            _statusToClientsListViewModel = new StatusToClientsListViewModel();
        }
    }
}
