using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class CreateProductCommand : BaseCommand
    {
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;
        private readonly CreateProductViewModel _createProductViewModel;

        public CreateProductCommand(NavigationService toListingNavigationService,
                                    IDataBase dataBase,
                                    CreateProductViewModel createProductViewModel)
        {
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
            _createProductViewModel = createProductViewModel;
        }

        public override void Execute(object? parameter)
        {
            Product product = new Product(_createProductViewModel.Name,
                                          _createProductViewModel.Price,
                                          (ProductType)_createProductViewModel.SelectedType,
                                          _createProductViewModel.SubscriptionExpirationDate);
            try
            {
                _dataBase.AddProduct(product);

                MessageBox.Show("Added new product successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
            catch (ProductAlreadyExistsException)
            {
                MessageBox.Show("Such product already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
    }
}
