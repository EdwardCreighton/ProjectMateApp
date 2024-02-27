using ProjectMateApp.Models;
using System.Windows.Input;

namespace ProjectMateApp.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
        private readonly Manager _manager;

        public string Name => _manager.Name;
        public ICommand EditManagerCommand { get; }

        public ManagerViewModel(Manager manager)
        {
            _manager = manager;
        }
    }
}
