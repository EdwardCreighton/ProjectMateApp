using ProjectMateApp.Models;
using ProjectMateApp.Services;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class DeleteManagerCommand : BaseCommand
    {
        private readonly Func<Manager> _getManager;
        private readonly NavigationService _toListingNavigationService;
        private readonly IDataBase _dataBase;

        public DeleteManagerCommand(Func<Manager> getManager, NavigationService toListingNavigationService, IDataBase dataBase)
        {
            _getManager = getManager;
            _toListingNavigationService = toListingNavigationService;
            _dataBase = dataBase;
        }

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure you want to delete this manager?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                _dataBase.Delete(_getManager());

                MessageBox.Show("Manager was deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationService.Navigate();
            }
        }
    }
}
