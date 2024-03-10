using ProjectMateApp.Models;
using ProjectMateApp.Services;
using ProjectMateApp.Stores;
using ProjectMateApp.ViewModels;

namespace ProjectMateApp.Commands
{
    public class EditProductNavigateCommand : NavigateCommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Product _product;

        public EditProductNavigateCommand(NavigationStore navigationStore,
                                          NavigationService toEditProductNavigationService,
                                          Product product) : base(toEditProductNavigationService)
        {
            _navigationStore = navigationStore;
            _product = product;
        }

        public override void Execute(object? parameter)
        {
            base.Execute(parameter);

            ((EditProductViewModel)_navigationStore.CurrentViewModel).Product = _product;
        }
    }
}
