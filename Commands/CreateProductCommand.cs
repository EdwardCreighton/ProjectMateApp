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

            _createProductViewModel.PropertyChanged += PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_createProductViewModel.Name)
                && _createProductViewModel.Price > 0
                && _createProductViewModel.SubscriptionExpirationDate > DateTime.UtcNow
                && base.CanExecute(parameter);
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
            catch (DataBaseElementAlreadyExistsException)
            {
                MessageBox.Show("Such product already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName ==  nameof(Product.Name))
            {
                OnCanExecuteChanged();
            }

            if (e.PropertyName == nameof(Product.Price))
            {
                OnCanExecuteChanged();
            }

            if (e.PropertyName == nameof(Product.SubscriptionExpirationDate))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
