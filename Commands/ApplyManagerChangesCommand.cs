using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class ApplyManagerChangesCommand : BaseCommand
    {
        private readonly EditManagerViewModel _editManagerViewModel;
        private readonly Func<Manager> _manager;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public ApplyManagerChangesCommand(EditManagerViewModel editManagerViewModel,
                                          Func<Manager> manager,
                                          NavigationService toListingNavigationService,
                                          IDataBase dataBase)
        {
            _editManagerViewModel = editManagerViewModel;
            _manager = manager;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;

            _editManagerViewModel.PropertyChanged += PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editManagerViewModel.FirstName)
                && !string.IsNullOrEmpty(_editManagerViewModel.Surname)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string name = NameValidator.JoinName(_editManagerViewModel.FirstName,
                                                     _editManagerViewModel.Surname,
                                                     _editManagerViewModel.LastName);

                NameValidator.Validate(name);

                Manager temp = new Manager(name);
                Manager savedManager = _manager.Invoke();

                if (_dataBase.Exists(temp))
                {
                    MessageBox.Show("Manager with the same name exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    savedManager.Name = name;
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
            if (e.PropertyName ==  nameof(EditManagerViewModel.FirstName))
            {
                OnCanExecuteChanged();
            }

            if (e.PropertyName == nameof(EditManagerViewModel.Surname))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
