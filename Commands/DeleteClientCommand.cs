using ProjectMateApp.Services;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class DeleteClientCommand : BaseCommand
    {
        private readonly EditClientViewModel _editClientViewModel;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public DeleteClientCommand(EditClientViewModel editClientViewModel,
                                   NavigationService toListingNavigationService,
                                   IDataBase dataBase)
        {
            _editClientViewModel = editClientViewModel;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
        }

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure you want to delete this client?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                _dataBase.Delete(_editClientViewModel.Client);

                MessageBox.Show("Client was deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
        }
    }
}
