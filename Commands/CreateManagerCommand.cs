﻿using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Utils;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class CreateManagerCommand : BaseCommand
    {
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;
        private readonly CreateManagerViewModel _createManagerViewModel;

        public CreateManagerCommand(NavigationService toListingNavigationService,
                                    IDataBase dataBase,
                                    CreateManagerViewModel createManagerViewModel)
        {
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
            _createManagerViewModel = createManagerViewModel;

            _createManagerViewModel.PropertyChanged += PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_createManagerViewModel.FirstName)
                && !string.IsNullOrEmpty(_createManagerViewModel.Surname)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string name = NameValidator.JoinName(_createManagerViewModel.FirstName,
                                                     _createManagerViewModel.Surname,
                                                     _createManagerViewModel.LastName);

                NameValidator.Validate(name);

                _dataBase.Add(new Manager(name));

                MessageBox.Show("Successfully added new manager.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
            catch (DataBaseElementAlreadyExistsException)
            {
                MessageBox.Show("Manager already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NameContainsNumbersException)
            {
                MessageBox.Show("Name can not contain numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateManagerViewModel.FirstName))
            {
                OnCanExecuteChanged();
            }

            if (e.PropertyName == nameof(CreateManagerViewModel.Surname))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
