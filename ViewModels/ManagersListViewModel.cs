using System.Collections.ObjectModel;

namespace ProjectMateApp.ViewModels
{
    public class ManagersListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ManagerViewModel> _managers;

        public IEnumerable<ManagerViewModel> Managers => _managers;

        public ManagersListViewModel()
        {
            _managers = new ObservableCollection<ManagerViewModel>();
        }
    }
}
