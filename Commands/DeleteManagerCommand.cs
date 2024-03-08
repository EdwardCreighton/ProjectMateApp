using ProjectMateApp.Services;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class DeleteManagerCommand : BaseCommand
    {
        private readonly EditManagerViewModel _editManagerViewModel;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public DeleteManagerCommand(EditManagerViewModel editManagerViewModel, NavigationService toListingNavigationService, IDataBase dataBase)
        {
            _editManagerViewModel = editManagerViewModel;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
        }

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure you want to delete this manager?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                _dataBase.Delete(_editManagerViewModel.Manager);

                MessageBox.Show("Manager was deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
        }
    }
}
