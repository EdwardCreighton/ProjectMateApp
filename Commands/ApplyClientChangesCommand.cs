using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class ApplyClientChangesCommand : BaseCommand
    {
        private readonly EditClientViewModel _editClientViewModel;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public ApplyClientChangesCommand(EditClientViewModel editClientViewModel,
                                         NavigationService toListingNavigationService,
                                         IDataBase dataBase)
        {
            _editClientViewModel = editClientViewModel;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editClientViewModel.FirstName)
                && !string.IsNullOrEmpty(_editClientViewModel.Surname)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string name = NameValidator.JoinName(_editClientViewModel.FirstName,
                                                       _editClientViewModel.Surname,
                                                       _editClientViewModel.LastName);
                NameValidator.Validate(name);
                ClientStatus status = (ClientStatus)_editClientViewModel.SelectedStatusIndex;
                Manager manager = _dataBase.Managers.ElementAt(_editClientViewModel.SelectedManagerIndex);

                Client temp = new Client(name, status, manager);

                if (_dataBase.Exists(temp))
                {
                    MessageBox.Show("Client with the same name exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _editClientViewModel.Client.Name = name;
                    _editClientViewModel.Client.Status = status;
                    _editClientViewModel.Client.Manager = manager;

                    MessageBox.Show("Successfully renamed manager.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    _toListingNavigationService.Navigate();
                }
            }
            catch (NameContainsNumbersException)
            {
                MessageBox.Show("Name can not contain numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_editClientViewModel.FirstName))
            {
                OnCanExecuteChanged();
            }

            if (e.PropertyName == nameof(_editClientViewModel.Surname))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
