﻿using ProjectMateApp.Services;
using ProjectMateApp.Stores;

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

        public ListingViewModel(App app, NavigationStore navigationStore, IDataBase dataBase)
        {
            _managersListViewModel = new ManagersListViewModel(navigationStore,
                                                               new NavigationService(navigationStore, app.CreateManagerViewModel),
                                                               new NavigationService(navigationStore, app.EditManagerViewModel),
                                                               dataBase);

            _clientsListViewModel = new ClientsListViewModel(navigationStore,
                                                             new NavigationService(navigationStore, app.CreateClientViewModel),
                                                             new NavigationService(navigationStore, app.EditClientViewModel),
                                                             dataBase);

            _productsListViewModel = new ProductsListViewModel(navigationStore,
                new NavigationService(navigationStore, app.CreateProductViewModel),
                new NavigationService(navigationStore, app.EditProductViewModel),
                                                               dataBase: dataBase);

            _managerToClientsListViewModel = new ManagerToClientsListViewModel();
            _clientToProductsListViewModel = new ClientToProductsListViewModel();
            _statusToClientsListViewModel = new StatusToClientsListViewModel();
        }
    }
}
