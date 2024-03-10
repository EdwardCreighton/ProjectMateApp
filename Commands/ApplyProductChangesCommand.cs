using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class ApplyProductChangesCommand : BaseCommand
    {
        private readonly EditProductViewModel _editProductViewModel;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public ApplyProductChangesCommand(EditProductViewModel editProductViewModel,
                                          NavigationService toListingNavigationService,
                                          IDataBase dataBase)
        {
            _editProductViewModel = editProductViewModel;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;

            _editProductViewModel.PropertyChanged += PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editProductViewModel.Name)
                && !string.IsNullOrEmpty(_editProductViewModel.Price)
                && ((ProductType)_editProductViewModel.SelectedType == ProductType.PermanentLicense
                    || _editProductViewModel.SubscriptionExpirationDate > DateTime.UtcNow)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                PriceValidator.Validate(_editProductViewModel.Price);

                string name = _editProductViewModel.Name;
                int price = int.Parse(_editProductViewModel.Price);
                ProductType type = (ProductType)_editProductViewModel.SelectedType;
                DateTime subscriptionExpirationDate = _editProductViewModel.SubscriptionExpirationDate;

                Product temp = new Product(name, price, type, subscriptionExpirationDate);

                if (_dataBase.Exists(temp))
                {
                    MessageBox.Show("This product already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _editProductViewModel.Product.Name = name;
                    _editProductViewModel.Product.Price = price;
                    _editProductViewModel.Product.Type = type;
                    _editProductViewModel.Product.SubscriptionExpirationDate = subscriptionExpirationDate;

                    MessageBox.Show("Product data was updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    _toListingNavigationService.Navigate();
                }
            }
            catch (PriceContainsCharactersException)
            {
                MessageBox.Show("Price can not contain other characters than numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
