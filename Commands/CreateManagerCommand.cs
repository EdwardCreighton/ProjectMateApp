using ProjectMateApp.Exceptions;
using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class CreateManagerCommand : BaseCommand
    {
        private readonly NavigationService toListingNavigationService;
        private readonly IDataBase dataBase;
        private readonly CreateManagerViewModel createManagerViewModel;

        public CreateManagerCommand(NavigationService toListingNavigationService, IDataBase dataBase, CreateManagerViewModel createManagerViewModel)
        {
            this.toListingNavigationService = toListingNavigationService;
            this.dataBase = dataBase;
            this.createManagerViewModel = createManagerViewModel;
        }

        public override void Execute(object? parameter)
        {
            string name = Manager.JoinName(createManagerViewModel.FirstName, createManagerViewModel.Surname, createManagerViewModel.LastName);

            try
            {
                dataBase.AddManager(new Manager(name));

                MessageBox.Show("Successfully added new manager", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                toListingNavigationService.Navigate();
            }
            catch (ManagerAlreadyExistsException)
            {
                MessageBox.Show("Manager already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
