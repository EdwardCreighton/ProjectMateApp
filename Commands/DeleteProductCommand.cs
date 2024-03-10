using ProjectMateApp.Services;
using ProjectMateApp.ViewModels;
using System.Windows;

namespace ProjectMateApp.Commands
{
    public class DeleteProductCommand : BaseCommand
    {
        private readonly EditProductViewModel _editProductViewModel;
        private readonly NavigationService _toListingNavigationservice;
        private readonly IDataBase _dataBase;

        public DeleteProductCommand(EditProductViewModel editProductViewModel,
                                    NavigationService toListingNavigationservice,
                                    IDataBase dataBase)
        {
            _editProductViewModel = editProductViewModel;
            _toListingNavigationservice = toListingNavigationservice;
            _dataBase = dataBase;
        }

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure you want to delete this product?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                _dataBase.Delete(_editProductViewModel.Product);

                MessageBox.Show("Product was deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _toListingNavigationservice.Navigate();
            }
        }
    }
}
