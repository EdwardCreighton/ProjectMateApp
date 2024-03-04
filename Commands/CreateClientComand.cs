using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    class CreateClientComand : BaseCommand
    {
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;
        private readonly CreateClientViewModel _createClientViewModel;

        public CreateClientComand(NavigationService toListingNavigationService,
                                  IDataBase dataBase,
                                  CreateClientViewModel createClientViewModel)
        {
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
            _createClientViewModel = createClientViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string name = NameValidator.JoinName(_createClientViewModel.FirstName,
                                                       _createClientViewModel.Surname,
                                                       _createClientViewModel.LastName);

                NameValidator.Validate(name);

                _dataBase.AddClient(new Client(name,
                                               (ClientStatus)_createClientViewModel.SelectedStatusIndex,
                                               _dataBase.Managers.ElementAt(_createClientViewModel.SelectedManagerIndex)));

                MessageBox.Show("Successfully added new client.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
            catch (DataBaseElementAlreadyExistsException)
            {
                MessageBox.Show("Client already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NameContainsNumbersException)
            {
                MessageBox.Show("Name can not contain numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
